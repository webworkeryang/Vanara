﻿using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Flags used by WerGetFlags and WerSetFlags.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "8c5f08c0-e2d1-448c-9a57-ef19897f64c6")]
		[Flags]
		public enum WER_FAULT_REPORTING
		{
			/// <summary>Do not collect heap information in the event of an application crash or non-response.</summary>
			WER_FAULT_REPORTING_FLAG_NOHEAP = 1,

			/// <summary>Queue critical reports for the specified process. This does not show any UI.</summary>
			WER_FAULT_REPORTING_FLAG_QUEUE = 2,

			/// <summary>Do not suspend the process threads before reporting the error.</summary>
			WER_FAULT_REPORTING_FLAG_DISABLE_THREAD_SUSPENSION = 4,

			/// <summary>Queue critical reports and upload from the queue.</summary>
			WER_FAULT_REPORTING_FLAG_QUEUE_UPLOAD = 8,

			/// <summary>Always show error reporting UI for this process. This is applicable for interactive applications only.</summary>
			WER_FAULT_REPORTING_ALWAYS_SHOW_UI = 16,

			/// <summary>Undocumented.</summary>
			WER_FAULT_REPORTING_NO_UI = 32,

			/// <summary>Undocumented.</summary>
			WER_FAULT_REPORTING_FLAG_NO_HEAP_ON_QUEUE = 64,

			/// <summary>Undocumented.</summary>
			WER_FAULT_REPORTING_DISABLE_SNAPSHOT_CRASH = 128,

			/// <summary>Undocumented.</summary>
			WER_FAULT_REPORTING_DISABLE_SNAPSHOT_HANG = 256,

			/// <summary>Undocumented.</summary>
			WER_FAULT_REPORTING_CRITICAL = 512,

			/// <summary>Undocumented.</summary>
			WER_FAULT_REPORTING_DURABLE = 1024,
		}

		public enum WER_FILE_TYPE
		{
			WerFileTypeMicrodump = 1,
			WerFileTypeMinidump = 2,
			WerFileTypeHeapdump = 3,
			WerFileTypeUserDocument = 4,
			WerFileTypeOther = 5,
			WerFileTypeTriagedump = 6,
			WerFileTypeCustomDump = 7,
			WerFileTypeAuxiliaryDump = 8,
			WerFileTypeEtlTrace = 9,
			WerFileTypeMax
		}

		/// <summary>The file type.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "4b4bb1bb-6782-447a-901f-75702256d907")]
		public enum WER_REGISTER_FILE_TYPE
		{
			/// <summary>
			/// The document in use by the application at the time of the event. This document is only collected if the Watson server asks
			/// for it.
			/// </summary>
			WerRegFileTypeUserDocument = 1,

			/// <summary>Any other type of file.</summary>
			WerRegFileTypeOther = 2,

			/// <summary>The maximum value for the WER_REGISTER_FILE_TYPE enumeration type.</summary>
			WerRegFileTypeMax
		}

		public enum WER_REPORT_TYPE
		{
			WerReportNonCritical = 0,
			WerReportCritical = 1,
			WerReportApplicationCrash = 2,
			WerReportApplicationHang = 3,
			WerReportKernel = 4,
			WerReportInvalid
		}

		public enum WER_REPORT_UI
		{
			WerUIAdditionalDataDlgHeader = 1,
			WerUIIconFilePath = 2,
			WerUIConsentDlgHeader = 3,
			WerUIConsentDlgBody = 4,
			WerUIOnlineSolutionCheckText = 5,
			WerUIOfflineSolutionCheckText = 6,
			WerUICloseText = 7,
			WerUICloseDlgHeader = 8,
			WerUICloseDlgBody = 9,
			WerUICloseDlgButtonText = 10,
			WerUIMax
		}

		public enum WER_SUBMIT_RESULT
		{
			WerReportQueued = 1,
			WerReportUploaded = 2,
			WerReportDebug = 3,
			WerReportFailed = 4,
			WerDisabled = 5,
			WerReportCancelled = 6,
			WerDisabledQueue = 7,
			WerReportAsync = 8,
			WerCustomAction = 9,
			WerThrottled = 10,
			WerReportUploadedCab = 11,
			WerStorageLocationNotFound = 12,
			WerSubmitResultMax
		}

		/// <summary>
		/// <para>Retrieves the fault reporting settings for the specified process.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process. This handle must have the PROCESS_VM_READ or PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <param name="pdwFlags">
		/// <para>This parameter can contain one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_DISABLE_THREAD_SUSPENSION</term>
		/// <term>Do not suspend the process threads before reporting the error.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_NOHEAP</term>
		/// <term>Do not collect heap information in the event of an application crash or non-response.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_QUEUE</term>
		/// <term>Queue critical reports for the specified process. This does not show any UI.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_QUEUE_UPLOAD</term>
		/// <term>Queue critical reports and upload from the queue.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_ALWAYS_SHOW_UI</term>
		/// <term>Always show error reporting UI for this process. This is applicable for interactive applications only.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-wergetflags HRESULT WerGetFlags( HANDLE hProcess, PDWORD
		// pdwFlags );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "8c5f08c0-e2d1-448c-9a57-ef19897f64c6")]
		public static extern HRESULT WerGetFlags(IntPtr hProcess, out WER_FAULT_REPORTING pdwFlags);

		/// <summary>
		/// Registers a process to be included in the error report along with the main application process. Optionally specifies a thread
		/// within that registered process to get additional data from.
		/// </summary>
		/// <param name="processId">The Id of the process to register.</param>
		/// <param name="captureExtraInfoForThreadId">The Id of a thread within the registered process from which more information is requested.</param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of processId is 0.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>WER could not allocate a large enough heap for the data.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>
		/// Number of WER registered entries (memory blocks, metadata, files) exceeds max (WER_MAX_REGISTERED_ENTRIES) or number of processes
		/// exceeds max (WER_MAX_REGISTERED_DUMPCOLLECTION)
		/// </term>
		/// </item>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT WINAPI WerRegisterAdditionalProcess( DWORD processId, DWORD captureExtraInfoForThreadId); https://msdn.microsoft.com/en-us/library/windows/desktop/mt492585(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Werapi.h", MSDNShortId = "mt492585")]
		public static extern HRESULT WerRegisterAdditionalProcess(uint processId, uint captureExtraInfoForThreadId);

		/// <summary>
		/// <para>Registers app-specific metadata to be collected (in the form of key/value strings) when WER creates an error report.</para>
		/// </summary>
		/// <param name="key">
		/// <para>The "key" string for the metadata element being registered.</para>
		/// </param>
		/// <param name="value">
		/// <para>The value string for the metadata element being registered.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// Strings were NULL, key length was greater than 64 characters or was an invalid xml element name, orvalue length was greater than
		/// 128 characters or contained characters that were not ASCII printable characters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>WER could not allocate a large enough heap for the data</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>
		/// The maximum number of registered entries (WER_MAX_REGISTERED_ENTRIES) or maximum amount of registered metadata
		/// (WER_MAX_REGISTERED_METADATA) has been reached.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This API allows apps to integrate their own app-level telemetry with system-level telemetry (WER) by associating app metadata
		/// with crash reports corresponding to their processes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werregistercustommetadata HRESULT WerRegisterCustomMetadata(
		// PCWSTR key, PCWSTR value );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("werapi.h", MSDNShortId = "55FB3110-314A-4327-AA8F-3AF77B7006DD")]
		public static extern HRESULT WerRegisterCustomMetadata(string key, string value);

		/// <summary>
		/// <para>Marks a memory block (that is normally included by default in error reports) to be excluded from the error report.</para>
		/// </summary>
		/// <param name="address">
		/// <para>The starting address of the memory block.</para>
		/// </param>
		/// <param name="size">
		/// <para>The size of the memory block, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>address is NULL or size is 0.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>WER could not allocate a large enough heap for the data</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The number of registered entries exceeds the limit (WER_MAX_REGISTERED_ENTRIES).</term>
		/// </item>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This mechanism is intended for applications that hold large amounts of data in memory that aren't useful for root cause debugging
		/// and increase the size of the dump file unnecessarily. For example, some Xbox One games hold large amounts of texture data in
		/// memory that is included in error dumps by default.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werregisterexcludedmemoryblock HRESULT
		// WerRegisterExcludedMemoryBlock( const void *address, DWORD size );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "6CDA8EDD-C8A5-471D-9716-3AB29E571133")]
		public static extern HRESULT WerRegisterExcludedMemoryBlock(IntPtr address, uint size);

		/// <summary>
		/// <para>Registers a file to be collected when WER creates an error report.</para>
		/// </summary>
		/// <param name="pwzFile">
		/// <para>The full path to the file. The maximum length of this path is MAX_PATH characters.</para>
		/// </param>
		/// <param name="regFileType">
		/// <para>The file type. This parameter can be one of the following values from the <c>WER_REGISTER_FILE_TYPE</c> enumeration type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerRegFileTypeMax 3</term>
		/// <term>The maximum value for the WER_REGISTER_FILE_TYPE enumeration type.</term>
		/// </item>
		/// <item>
		/// <term>WerRegFileTypeOther 2</term>
		/// <term>Any other type of file.</term>
		/// </item>
		/// <item>
		/// <term>WerRegFileTypeUserDocument 1</term>
		/// <term>
		/// The document in use by the application at the time of the event. This document is only collected if the Watson server asks for it.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WER_FILE_ANONYMOUS_DATA</term>
		/// <term>The file does not contain personal information that could be used to identify or contact the user.</term>
		/// </item>
		/// <item>
		/// <term>WER_FILE_DELETE_WHEN_DONE</term>
		/// <term>Automatically deletes the file after it is added to the report.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The number of registered memory blocks and files exceeds the limit.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The registered file is added to the report only when additional data is requested by the server.</para>
		/// <para>
		/// For crashes and non-responses, the operating system automatically provides error reporting (you do not need to provide any error
		/// reporting code in your application). If you use this function to register a file, the operating system will add the file to the
		/// error report created at the time of a crash or non-response (this file is added in addition to the files the operating system
		/// already collects).
		/// </para>
		/// <para>
		/// For generic event reporting, the application has to use the WerReportAddFile function instead. Alternatively, calling the
		/// WerReportSubmit function with the WER_SUBMIT_ADD_REGISTERED_DATA flag will include the files that the <c>WerRegisterFile</c>
		/// function added.
		/// </para>
		/// <para>To remove the file from the list, call the WerUnregisterFile function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werregisterfile HRESULT WerRegisterFile( PCWSTR pwzFile,
		// WER_REGISTER_FILE_TYPE regFileType, DWORD dwFlags );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "4b4bb1bb-6782-447a-901f-75702256d907")]
		public static extern HRESULT WerRegisterFile([MarshalAs(UnmanagedType.LPWStr)] string pwzFile, WER_REGISTER_FILE_TYPE regFileType, uint dwFlags);

		/// <summary>
		/// <para>Registers a memory block to be collected when WER creates an error report.</para>
		/// </summary>
		/// <param name="pvAddress">
		/// <para>The starting address of the memory block.</para>
		/// </param>
		/// <param name="dwSize">
		/// <para>The size of the memory block, in bytes. The maximum value for this parameter is WER_MAX_MEM_BLOCK_SIZE bytes.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The number of registered memory blocks and files exceeds the limit.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Memory registered with this function is only added to heap or larger dump files. This memory is never added to mini dumps or
		/// smaller dump files.
		/// </para>
		/// <para>
		/// For crashes and no response, the operating system automatically provides error reporting (you do not need to provide any error
		/// reporting code in your application). If you use this function to register a memory block, the operating system will add the
		/// memory block information to the dump file at the time of the crash or non-response. The memory block is added to the dump file
		/// for the report only when additional data is requested by the server.
		/// </para>
		/// <para>
		/// For generic event reporting, the application has to call the WER generic event reporting functions directly. To add the memory
		/// block to a generic report, call the WerReportAddDump function and then call the WerReportSubmit function and specify the
		/// WER_SUBMIT_ADD_REGISTERED_DATA flag.
		/// </para>
		/// <para>To remove the block from this list, call the WerUnregisterMemoryBlock function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werregistermemoryblock HRESULT WerRegisterMemoryBlock( PVOID
		// pvAddress, DWORD dwSize );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "10fa2bf3-ec12-4c7c-b986-9b22cdaa7319")]
		public static extern HRESULT WerRegisterMemoryBlock(IntPtr pvAddress, uint dwSize);

		/// <summary>
		/// <para>Registers a custom runtime exception handler that is used to provide custom error reporting for crashes.</para>
		/// </summary>
		/// <param name="pwszOutOfProcessCallbackDll">
		/// <para>The name of the exception handler DLL to register.</para>
		/// </param>
		/// <param name="pContext">
		/// <para>A pointer to arbitrary context information that is passed to the handler's callback functions.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>
		/// The number of registered runtime exception modules exceeds the limit. A process can register up to
		/// WER_MAX_REGISTERED_RUNTIME_EXCEPTION_MODULES handlers.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The exception handler is an out-of-process DLL that the WER service loads when a crash or unhandled exception occurs. The DLL
		/// must implement and export the following functions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>OutOfProcessExceptionEventCallback</term>
		/// </item>
		/// <item>
		/// <term>OutOfProcessExceptionEventSignatureCallback</term>
		/// </item>
		/// <item>
		/// <term>OutOfProcessExceptionEventDebuggerLaunchCallback</term>
		/// </item>
		/// </list>
		/// <para>(The DLL must also include the DllMain entry point.)</para>
		/// <para>
		/// Using an exception handler is more secure and reliable for reporting crash information than the current, in-process event
		/// reporting feature. Also, the current generic event reporting feature is suited only for reporting non-fatal errors.
		/// </para>
		/// <para>
		/// This function requires that the pwszOutOfProcessCallbackDll DLL be included in the WER exception handler module list in the
		/// registry. After registering an exception handler, if the process crashes or raises an unhandled exception, the WER service loads
		/// your exception handler and calls the OutOfProcessExceptionEventCallback callback function., which you use to state your claim on
		/// the crash and provide the event name and report parameters count. Note that if the process registers more than one exception
		/// handler, the service calls each handler until one of the handlers claims the crash. If no handlers claim the crash, WER defaults
		/// to native crash reporting.
		/// </para>
		/// <para>
		/// If an exception handler claims the exception, the WER service calls the OutOfProcessExceptionEventSignatureCallback callback
		/// function, which provides the reporting parameters that uniquely define the problem. Then, the WER service calls the
		/// OutOfProcessExceptionEventDebuggerLaunchCallback callback to determine whether to offer the user the option of launching a
		/// debugger or launching the debugger automatically. The handler can also specify a custom debugger launch string, which will
		/// override the default string (the default is the debugger specified in the AeDebug registry key).
		/// </para>
		/// <para>
		/// After the handler has provided the event name, reporting parameters and debugger launch settings, the rest of the error reporting
		/// flow continues in the usual way.
		/// </para>
		/// <para>
		/// You must call the WerUnregisterRuntimeExceptionModule function to remove the registration before your process exits. A process
		/// can register up to WER_MAX_REGISTERED_RUNTIME_EXCEPTION_MODULES handlers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werregisterruntimeexceptionmodule HRESULT
		// WerRegisterRuntimeExceptionModule( PCWSTR pwszOutOfProcessCallbackDll, PVOID pContext );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "b0fb2c0d-cc98-43cc-a508-e80545377b7f")]
		public static extern HRESULT WerRegisterRuntimeExceptionModule([MarshalAs(UnmanagedType.LPWStr)] string pwszOutOfProcessCallbackDll, IntPtr pContext);

		/// <summary>
		/// <para>Sets the fault reporting settings for the current process.</para>
		/// </summary>
		/// <param name="dwFlags">
		/// <para>The fault reporting settings. You can specify one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_DISABLE_THREAD_SUSPENSION</term>
		/// <term>Do not suspend the process threads before reporting the error.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_NOHEAP</term>
		/// <term>Do not collect heap information in the event of an application crash or non-response.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_QUEUE</term>
		/// <term>Queue critical reports.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_FLAG_QUEUE_UPLOAD</term>
		/// <term>Queue critical reports and upload from the queue.</term>
		/// </item>
		/// <item>
		/// <term>WER_FAULT_REPORTING_ALWAYS_SHOW_UI</term>
		/// <term>Always show error reporting UI for this process. This is applicable for interactive applications only.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-wersetflags HRESULT WerSetFlags( DWORD dwFlags );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "2a71203f-3a08-461f-a230-e3fee00d9d99")]
		public static extern HRESULT WerSetFlags(WER_FAULT_REPORTING dwFlags);

		/// <summary>
		/// <para>Removes a process from the list of additional processes to be included in the error report.</para>
		/// </summary>
		/// <param name="processId">
		/// <para>The Id of the process to remove. It must have been previously registered with WerRegisterAdditionalProcess.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>WER_E_NOT_FOUND</term>
		/// <term>The list of registered processes does not contain the specified process.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werunregisteradditionalprocess HRESULT
		// WerUnregisterAdditionalProcess( DWORD processId );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "CE840EE8-5EB6-4F0F-935E-5DA9097E950F")]
		public static extern HRESULT WerUnregisterAdditionalProcess(uint processId);

		/// <summary>
		/// <para>Removes an item of app-specific metadata being collected during error reporting for the application.</para>
		/// </summary>
		/// <param name="key">
		/// <para>
		/// The "key" string for the metadata element being removed. It must have been previously registered with the
		/// WerRegisterCustomMetadata function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>WER_E_NOT_FOUND</term>
		/// <term>WER could not find the metadata item to remove.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werunregistercustommetadata HRESULT
		// WerUnregisterCustomMetadata( PCWSTR key );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "29DB2CE5-2A96-450B-96C8-082B786613F9")]
		public static extern HRESULT WerUnregisterCustomMetadata([MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>
		/// <para>Removes a memory block that was previously marked as excluded (it will again be included in error reports).</para>
		/// </summary>
		/// <param name="address">
		/// <para>
		/// The starting address of the memory block. This memory block must have been registered using the WerRegisterExcludedMemoryBlock function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werunregisterexcludedmemoryblock HRESULT
		// WerUnregisterExcludedMemoryBlock( const void *address );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "99FF746E-8EFC-47DB-AEE6-EC46F7BC7F0B")]
		public static extern HRESULT WerUnregisterExcludedMemoryBlock(IntPtr address);

		/// <summary>Removes a file from the list of files to be added to reports generated for the current process.</summary>
		/// <param name="pwzFilePath">The full path to the file. This file must have been registered using the <c>WerRegisterFile</c> function.</param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>WER_E_NOT_FOUND</term>
		/// <term>The list of registered files does not contain the specified file.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT WINAPI WerUnregisterFile( _In_ PCWSTR pwzFilePath); https://msdn.microsoft.com/en-us/library/windows/desktop/bb513630(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Werapi.h", MSDNShortId = "bb513630")]
		public static extern HRESULT WerUnregisterFile([MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath);

		/// <summary>
		/// <para>Removes a memory block from the list of data to be collected during error reporting for the application.</para>
		/// </summary>
		/// <param name="pvAddress">
		/// <para>
		/// The starting address of the memory block. This memory block must have been registered using the WerRegisterMemoryBlock function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>WER_E_NOT_FOUND</term>
		/// <term>The list of registered memory blocks does not contain the specified memory block.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werunregistermemoryblock HRESULT WerUnregisterMemoryBlock(
		// PVOID pvAddress );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "016800e8-4a03-40f6-9dba-54cd9082eb48")]
		public static extern HRESULT WerUnregisterMemoryBlock(IntPtr pvAddress);

		/// <summary>
		/// <para>Removes the registration of your WER exception handler.</para>
		/// </summary>
		/// <param name="pwszOutOfProcessCallbackDll">
		/// <para>The name of the exception handler DLL whose registration you want to remove.</para>
		/// </param>
		/// <param name="pContext">
		/// <para>A pointer to arbitrary context information that was passed to the callback.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WER_E_INVALID_STATE</term>
		/// <term>The process state is not valid. For example, the process is in application recovery mode.</term>
		/// </item>
		/// <item>
		/// <term>WER_E_NOT_FOUND</term>
		/// <term>The list of registered runtime exception handlers does not contain the specified exception handler.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>To register your runtime exception handler, call the WerRegisterRuntimeExceptionModule function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werunregisterruntimeexceptionmodule HRESULT
		// WerUnregisterRuntimeExceptionModule( PCWSTR pwszOutOfProcessCallbackDll, PVOID pContext );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "1a315923-b554-4363-a607-076690fc76a1")]
		public static extern HRESULT WerUnregisterRuntimeExceptionModule([MarshalAs(UnmanagedType.LPWStr)] string pwszOutOfProcessCallbackDll, IntPtr pContext);
	}
}