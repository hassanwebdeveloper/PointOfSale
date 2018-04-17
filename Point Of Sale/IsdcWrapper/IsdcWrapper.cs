using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IntermecIsdc
{
    public enum DllErrorCode : ushort
    {
        NO_ERROR = 0,
        INVALID_INPUT_BUFFER = 1,
        OUTPUT_BUFFER_TO_SMALL = 2,
        REGISTRY_ERROR = 3,
        ALLOCATION_ERROR = 4,
        RESERVED = 5,
        RESERVED1 = 6,
        DLL_NOT_INITIALIZED = 7,
        NO_DEVICE_FOUND = 8,
        INTERF_PORT_NOT_AVAILABLE = 9,
        CONNECTION_LOST = 10,
        OPERATION_CANCELLED = 11,
        INTERNAL_ERROR = 12,
        NOT_SUPPORTED = 13,
    }
    public class IsdcWrapper
    {
        #region Constantes
        const String DllName = "ISDC_PnP.dll";
        const UInt32 MaxStrLength = 1024;
        #endregion

        #region ImportDll

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("user32", EntryPoint = "RegisterWindowMessage")]
        private static extern int _RegisterWindowMessage(string lpString);



        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "ConfigurationDialog", SetLastError = true,
             
             CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _ConfigurationDialog();

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "Connect", SetLastError = true,
             
             CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _Connect();

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "ControlCommand", SetLastError = true,
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _ControlCommand(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "ControlPermissionRead", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _ControlPermissionRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "ControlPermissionWrite", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _ControlPermissionWrite(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "ControlRangeRead", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _ControlRangeRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "Deinitialize", SetLastError = true,
            
            CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _Deinitialize();

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "DeviceIOControl", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _DeviceIOControl(
                    UInt32 IoControlCode,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "Disconnect", SetLastError = true,
            
            CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _Disconnect();

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetBarcodeData", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetBarcodeData(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetBarcodeDataEx", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetBarcodeDataEx(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetBarcodeDataEx2", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetBarcodeDataEx2(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetDllVersion", SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetDllVersion([MarshalAs(UnmanagedType.LPArray)] Byte[] pOutputBuffer, UInt32 nSizeOfOutputBuffer, out UInt32 pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetEventNotification", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetEventNotification(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetImageData", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetImageData(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetSetupBarcodeData", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetSetupBarcodeData(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "GetRawData", SetLastError = true,
            
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _GetRawData(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "ImageDataRead", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _ImageDataRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "Initialize", SetLastError = true,
             
            CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _Initialize([MarshalAs(UnmanagedType.LPArray)] Byte[] pszRegistryKey, Byte[] Status);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "MessageIdentify", SetLastError = true,
            
            CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _MessageIdentify(UInt32 handle, Byte ID);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "SetupPermissionRead", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _SetupPermissionRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "SetupPermissionWrite", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _SetupPermissionWrite(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "SetupRangeRead", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _SetupRangeRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "SetupRead", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _SetupRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "SetupWrite", SetLastError = true,
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _SetupWrite(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "StatusPermissionRead", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _StatusPermissionRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "StatusPermissionWrite", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _StatusPermissionWrite(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport(DllName, EntryPoint = "StatusRead", SetLastError = true,
           
                    CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 _StatusRead(
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pInputBuffer,
                    UInt32 nBytesInInputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)]Byte[] pOutputBuffer,
                    UInt32 nBytesInOutputBuffer,
                    [MarshalAs(UnmanagedType.LPArray)] UInt32[] pnBytesReturned);
        #endregion

        public virtual int RegisterWindowMessage(string lpString)
        {
            return _RegisterWindowMessage(lpString);
        }

        public virtual DllErrorCode ConfigurationDialog()
        {
            return (DllErrorCode)_ConfigurationDialog();
        }

        public virtual DllErrorCode Connect()
        {
            return (DllErrorCode)_Connect();
        }

        public virtual DllErrorCode ControlCommand(Byte[] pInputBuffer,UInt32 nBytesInInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];            
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_ControlCommand(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode ControlPermissionRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_ControlPermissionRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode ControlPermissionWrite(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_ControlPermissionWrite(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode ControlRangeRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_ControlRangeRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode Deinitialize()
        {
            return (DllErrorCode)_Deinitialize();
        }


        public virtual DllErrorCode Disconnect()
        {
            return (DllErrorCode)_Disconnect();
        }

        public virtual DllErrorCode GetBarcodeData(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetBarcodeData(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode GetBarcodeDataEx(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetBarcodeDataEx(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode GetBarcodeDataEx2(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetBarcodeDataEx2(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode GetDllVersion(out String Version)
        {
            UInt32 length;
            Byte[] buffer = new Byte[MaxStrLength];

            Version = null;
            DllErrorCode result = (DllErrorCode)_GetDllVersion(buffer, MaxStrLength, out length);
            if (result == DllErrorCode.NO_ERROR)
            {
                int index = Array.IndexOf<byte>(buffer, 0);
                Version = System.Text.Encoding.ASCII.GetString(buffer, 0, index);
            }
            return result;
        }

        public virtual DllErrorCode GetEventNotification(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetEventNotification(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode GetImageData(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetImageData(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode GetSetupBarcodeData(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetSetupBarcodeData(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode GetRawData(Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_GetRawData(pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode ImageDataRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_ImageDataRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode Initialise(String pszRegistryKey, out Byte Status)
        {
            Byte[] _status = new Byte[1];
            DllErrorCode _result;
            byte[] Buff = new Byte[pszRegistryKey.Length + 1];
            int test = System.Text.Encoding.ASCII.GetBytes(pszRegistryKey, 0, pszRegistryKey.Length, Buff, 0);
            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(pszRegistryKey);
            _result = (DllErrorCode)_Initialize(Buff, _status);
            Status = _status[0];

            return _result;
        }

        public virtual DllErrorCode MessageIdentify(UInt32 handle, Byte ID)
        {
            return (DllErrorCode)_MessageIdentify(handle, ID);
        }

        public virtual DllErrorCode SetupPermissionRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_SetupPermissionRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode SetupPermissionWrite(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_SetupPermissionWrite(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode SetupRangeRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_SetupRangeRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode SetupRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_SetupRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode SetupWrite(Byte[] pInputBuffer,UInt32 nBytesInInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_SetupWrite(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode StatusPermissionRead(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_StatusPermissionRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode StatusPermissionWrite(Byte[] pInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];
            UInt32 nBytesInInputBuffer = (UInt32)pInputBuffer.GetLength(0);
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_StatusPermissionWrite(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }

        public virtual DllErrorCode StatusRead(Byte[] pInputBuffer, uint nBytesInInputBuffer, Byte[] pOutputBuffer, out UInt32 nBytesReturned)
        {
            UInt32[] len = new UInt32[1];            
            UInt32 nBytesInOutputBuffer = (UInt32)pOutputBuffer.GetLength(0);
            DllErrorCode retVal = (DllErrorCode)_StatusRead(pInputBuffer, nBytesInInputBuffer, pOutputBuffer, nBytesInOutputBuffer, len);
            nBytesReturned = len[0];
            return retVal;
        }
    }
}
