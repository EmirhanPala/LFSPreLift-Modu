using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class Class1
    {
        [Flags]
        public enum ProcessAccessType
        {
            PROCESS_TERMINATE = (0x0001),
            PROCESS_CREATE_THREAD = (0x0002),
            PROCESS_SET_SESSIONID = (0x0004),
            PROCESS_VM_OPERATION = (0x0008),
            PROCESS_VM_READ = (0x0010),
            PROCESS_VM_WRITE = (0x0020),
            PROCESS_DUP_HANDLE = (0x0040),
            PROCESS_CREATE_PROCESS = (0x0080),
            PROCESS_SET_QUOTA = (0x0100),
            PROCESS_SET_INFORMATION = (0x0200),
            PROCESS_QUERY_INFORMATION = (0x0400)
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);
 
 
        public bool StartHacking(string ApplicationX)
        {
            Process[] pArray = Process.GetProcessesByName(ApplicationX);
            if (pArray.Length == 0) { return false; }
            ReadProcess = pArray[0];
            Open();
            return true;
        }
        public void StopHacking()
        {
            try
            {
                int iRetValue;
                iRetValue = CloseHandle(m_hProcess);
                if (iRetValue == 0)
                    iRetValue = 0;
 
            }
            catch { }
        }
        public void WriteInt(int Address, int Value, int bytes)
        {
            int byteswritten;
            WriteFix((IntPtr)Address, BitConverter.GetBytes(Value), bytes, out byteswritten);
        }
        public void WriteFloat(int Address, float Value, int bytes)
        {
            int byteswritten;
            WriteFix((IntPtr)Address, BitConverter.GetBytes(Value), bytes, out byteswritten);
        }
        public void WriteDouble(int Address, double Value, int bytes)
        {
            int byteswritten;
            WriteFix((IntPtr)Address, BitConverter.GetBytes(Value), bytes, out byteswritten);
        }
        public void WriteBytes(int Address, byte[] Value, int bytes)
        {
            int byteswritten;
            WriteFix((IntPtr)Address, Value, bytes, out byteswritten);
        }
        public void WriteNOP(int Address)
        {
            byte[] nop = { 0x90, 0x90, 0x90, 0x90, 0x90 };
            WriteBytes(Address, nop, 5);
        }
 
        private Process ReadProcess
        {
            get
            {
                return m_ReadProcess;
            }
            set
            {
                m_ReadProcess = value;
            }
        }
        private Process m_ReadProcess = null;
        private IntPtr m_hProcess = IntPtr.Zero;
        private void Open()
        {
            ProcessAccessType access;
            access = ProcessAccessType.PROCESS_VM_READ
            | ProcessAccessType.PROCESS_VM_WRITE
            | ProcessAccessType.PROCESS_VM_OPERATION;
            m_hProcess = OpenProcess((uint)access, 1, (uint)m_ReadProcess.Id);
        }
        private void WriteFix(IntPtr MemoryAddress, byte[] bytesToWrite, int BytesToWrite, out int bytesWritten)
        {
            IntPtr ptrBytesWritten;
            WriteProcessMemory(m_hProcess, MemoryAddress, bytesToWrite, (uint)BytesToWrite, out ptrBytesWritten);
            bytesWritten = ptrBytesWritten.ToInt32();
        }
    }
 
 
    public class Extra
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vkey);

        public bool Hotkey(Keys Hotkey)
        {
            bool HotKeyX = Convert.ToBoolean(GetAsyncKeyState(Hotkey));
            if (HotKeyX)
                return true;
            else
                return false;
        }
    }


    }

