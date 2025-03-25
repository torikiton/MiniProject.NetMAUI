#include <stdlib.h>

static void xamarin_initialize_dotnet ()
{
}

extern "C" void xamarin_initialize_dotnet();
extern "C" void xamarin_create_classes();

static void xamarin_invoke_registration_methods ()
{
	xamarin_initialize_dotnet();
	xamarin_create_classes();
}

#include "xamarin/xamarin.h"

extern void *mono_aot_module_aot_instances_info;
extern void *mono_aot_module_MiniProject_info;
extern void *mono_aot_module_CommunityToolkit_Mvvm_info;
extern void *mono_aot_module_Microsoft_Extensions_Configuration_info;
extern void *mono_aot_module_Microsoft_Extensions_Configuration_Abstractions_info;
extern void *mono_aot_module_Microsoft_Extensions_DependencyInjection_info;
extern void *mono_aot_module_Microsoft_Extensions_DependencyInjection_Abstractions_info;
extern void *mono_aot_module_Microsoft_Extensions_Logging_info;
extern void *mono_aot_module_Microsoft_Extensions_Logging_Abstractions_info;
extern void *mono_aot_module_Microsoft_Extensions_Options_info;
extern void *mono_aot_module_Microsoft_Extensions_Primitives_info;
extern void *mono_aot_module_Microsoft_Maui_Controls_info;
extern void *mono_aot_module_Microsoft_Maui_Controls_Xaml_info;
extern void *mono_aot_module_Microsoft_Maui_info;
extern void *mono_aot_module_Microsoft_Maui_Essentials_info;
extern void *mono_aot_module_Microsoft_Maui_Graphics_info;
extern void *mono_aot_module_Newtonsoft_Json_info;
extern void *mono_aot_module_Microsoft_CSharp_info;
extern void *mono_aot_module_System_Collections_Concurrent_info;
extern void *mono_aot_module_System_Collections_NonGeneric_info;
extern void *mono_aot_module_System_Collections_Specialized_info;
extern void *mono_aot_module_System_Collections_info;
extern void *mono_aot_module_System_ComponentModel_Primitives_info;
extern void *mono_aot_module_System_ComponentModel_TypeConverter_info;
extern void *mono_aot_module_System_ComponentModel_info;
extern void *mono_aot_module_System_Console_info;
extern void *mono_aot_module_System_Data_Common_info;
extern void *mono_aot_module_System_Diagnostics_DiagnosticSource_info;
extern void *mono_aot_module_System_Diagnostics_TraceSource_info;
extern void *mono_aot_module_System_Drawing_Primitives_info;
extern void *mono_aot_module_System_Drawing_info;
extern void *mono_aot_module_System_IO_Pipelines_info;
extern void *mono_aot_module_System_Linq_Expressions_info;
extern void *mono_aot_module_System_Linq_info;
extern void *mono_aot_module_System_Memory_info;
extern void *mono_aot_module_System_Net_Http_info;
extern void *mono_aot_module_System_Net_Primitives_info;
extern void *mono_aot_module_System_Net_Requests_info;
extern void *mono_aot_module_System_Net_Security_info;
extern void *mono_aot_module_System_Numerics_Vectors_info;
extern void *mono_aot_module_System_ObjectModel_info;
extern void *mono_aot_module_System_Private_Uri_info;
extern void *mono_aot_module_System_Private_Xml_Linq_info;
extern void *mono_aot_module_System_Private_Xml_info;
extern void *mono_aot_module_System_Reflection_Emit_ILGeneration_info;
extern void *mono_aot_module_System_Reflection_Emit_Lightweight_info;
extern void *mono_aot_module_System_Reflection_Primitives_info;
extern void *mono_aot_module_System_Runtime_InteropServices_info;
extern void *mono_aot_module_System_Runtime_Loader_info;
extern void *mono_aot_module_System_Runtime_Numerics_info;
extern void *mono_aot_module_System_Runtime_Serialization_Formatters_info;
extern void *mono_aot_module_System_Runtime_Serialization_Primitives_info;
extern void *mono_aot_module_System_Runtime_info;
extern void *mono_aot_module_System_Security_Cryptography_info;
extern void *mono_aot_module_System_Text_Encoding_Extensions_info;
extern void *mono_aot_module_System_Text_Encodings_Web_info;
extern void *mono_aot_module_System_Text_Json_info;
extern void *mono_aot_module_System_Text_RegularExpressions_info;
extern void *mono_aot_module_System_Threading_Thread_info;
extern void *mono_aot_module_System_Threading_info;
extern void *mono_aot_module_System_Web_HttpUtility_info;
extern void *mono_aot_module_System_Xml_Linq_info;
extern void *mono_aot_module_System_Xml_ReaderWriter_info;
extern void *mono_aot_module_System_Xml_XDocument_info;
extern void *mono_aot_module_System_info;
extern void *mono_aot_module_System_Private_CoreLib_info;
extern void *mono_aot_module_Microsoft_MacCatalyst_info;

void xamarin_register_modules_impl ()
{
	mono_aot_register_module (mono_aot_module_aot_instances_info);
	mono_aot_register_module (mono_aot_module_MiniProject_info);
	mono_aot_register_module (mono_aot_module_CommunityToolkit_Mvvm_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_Configuration_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_Configuration_Abstractions_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_DependencyInjection_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_DependencyInjection_Abstractions_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_Logging_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_Logging_Abstractions_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_Options_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Extensions_Primitives_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Maui_Controls_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Maui_Controls_Xaml_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Maui_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Maui_Essentials_info);
	mono_aot_register_module (mono_aot_module_Microsoft_Maui_Graphics_info);
	mono_aot_register_module (mono_aot_module_Newtonsoft_Json_info);
	mono_aot_register_module (mono_aot_module_Microsoft_CSharp_info);
	mono_aot_register_module (mono_aot_module_System_Collections_Concurrent_info);
	mono_aot_register_module (mono_aot_module_System_Collections_NonGeneric_info);
	mono_aot_register_module (mono_aot_module_System_Collections_Specialized_info);
	mono_aot_register_module (mono_aot_module_System_Collections_info);
	mono_aot_register_module (mono_aot_module_System_ComponentModel_Primitives_info);
	mono_aot_register_module (mono_aot_module_System_ComponentModel_TypeConverter_info);
	mono_aot_register_module (mono_aot_module_System_ComponentModel_info);
	mono_aot_register_module (mono_aot_module_System_Console_info);
	mono_aot_register_module (mono_aot_module_System_Data_Common_info);
	mono_aot_register_module (mono_aot_module_System_Diagnostics_DiagnosticSource_info);
	mono_aot_register_module (mono_aot_module_System_Diagnostics_TraceSource_info);
	mono_aot_register_module (mono_aot_module_System_Drawing_Primitives_info);
	mono_aot_register_module (mono_aot_module_System_Drawing_info);
	mono_aot_register_module (mono_aot_module_System_IO_Pipelines_info);
	mono_aot_register_module (mono_aot_module_System_Linq_Expressions_info);
	mono_aot_register_module (mono_aot_module_System_Linq_info);
	mono_aot_register_module (mono_aot_module_System_Memory_info);
	mono_aot_register_module (mono_aot_module_System_Net_Http_info);
	mono_aot_register_module (mono_aot_module_System_Net_Primitives_info);
	mono_aot_register_module (mono_aot_module_System_Net_Requests_info);
	mono_aot_register_module (mono_aot_module_System_Net_Security_info);
	mono_aot_register_module (mono_aot_module_System_Numerics_Vectors_info);
	mono_aot_register_module (mono_aot_module_System_ObjectModel_info);
	mono_aot_register_module (mono_aot_module_System_Private_Uri_info);
	mono_aot_register_module (mono_aot_module_System_Private_Xml_Linq_info);
	mono_aot_register_module (mono_aot_module_System_Private_Xml_info);
	mono_aot_register_module (mono_aot_module_System_Reflection_Emit_ILGeneration_info);
	mono_aot_register_module (mono_aot_module_System_Reflection_Emit_Lightweight_info);
	mono_aot_register_module (mono_aot_module_System_Reflection_Primitives_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_InteropServices_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_Loader_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_Numerics_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_Serialization_Formatters_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_Serialization_Primitives_info);
	mono_aot_register_module (mono_aot_module_System_Runtime_info);
	mono_aot_register_module (mono_aot_module_System_Security_Cryptography_info);
	mono_aot_register_module (mono_aot_module_System_Text_Encoding_Extensions_info);
	mono_aot_register_module (mono_aot_module_System_Text_Encodings_Web_info);
	mono_aot_register_module (mono_aot_module_System_Text_Json_info);
	mono_aot_register_module (mono_aot_module_System_Text_RegularExpressions_info);
	mono_aot_register_module (mono_aot_module_System_Threading_Thread_info);
	mono_aot_register_module (mono_aot_module_System_Threading_info);
	mono_aot_register_module (mono_aot_module_System_Web_HttpUtility_info);
	mono_aot_register_module (mono_aot_module_System_Xml_Linq_info);
	mono_aot_register_module (mono_aot_module_System_Xml_ReaderWriter_info);
	mono_aot_register_module (mono_aot_module_System_Xml_XDocument_info);
	mono_aot_register_module (mono_aot_module_System_info);
	mono_aot_register_module (mono_aot_module_System_Private_CoreLib_info);
	mono_aot_register_module (mono_aot_module_Microsoft_MacCatalyst_info);

}

void xamarin_register_assemblies_impl ()
{
	GCHandle exception_gchandle = INVALID_GCHANDLE;
	xamarin_open_and_register ("Microsoft.Maui.Controls.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);
	xamarin_open_and_register ("Microsoft.Maui.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);
	xamarin_open_and_register ("Microsoft.Maui.Essentials.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);
	xamarin_open_and_register ("Microsoft.Maui.Graphics.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);
	xamarin_open_and_register ("Microsoft.MacCatalyst.dll", &exception_gchandle);
	xamarin_process_managed_exception_gchandle (exception_gchandle);

}

static const char *xamarin_runtime_libraries_array[] = {
	"libSystem.Globalization.Native",
	"libSystem.IO.Compression.Native",
	"libSystem.Native",
	"libSystem.Net.Security.Native",
	"libSystem.Security.Cryptography.Native.Apple",
	"libmono-component-debugger-stub-static",
	"libmono-component-diagnostics_tracing-stub-static",
	"libmono-component-hot_reload-stub-static",
	"libmono-component-marshal-ilgen-static",
	"libmonosgen-2.0",
	"libmono-component-marshal-ilgen-static",
	"libmono-component-debugger-stub-static",
	"libmono-component-hot_reload-stub-static",
	"libmono-component-diagnostics_tracing-stub-static",
	NULL
};
void xamarin_setup_impl ()
{
	mono_jit_set_aot_mode (MONO_AOT_MODE_FULL);
	xamarin_invoke_registration_methods ();
	xamarin_libmono_native_link_mode = XamarinNativeLinkModeStaticObject;
	xamarin_runtime_libraries = xamarin_runtime_libraries_array;
	xamarin_init_mono_debug = FALSE;
	xamarin_executable_name = "MiniProject.dll";
	mono_use_llvm = FALSE;
	xamarin_log_level = 0;
	xamarin_arch_name = "arm64";
	xamarin_marshal_objectivec_exception_mode = MarshalObjectiveCExceptionModeThrowManagedException;
	setenv ("MONO_GC_PARAMS", "major=marksweep", 1);
	xamarin_supports_dynamic_registration = FALSE;
	xamarin_runtime_configuration_name = "runtimeconfig.bin";
	xamarin_set_is_managed_static_registrar (true);
}

int main (int argc, char **argv)
{
	NSAutoreleasePool *pool = [[NSAutoreleasePool alloc] init];
	int rv = xamarin_main (argc, argv, XamarinLaunchModeApp);
	[pool drain];
	return rv;
}

void xamarin_initialize_callbacks () __attribute__ ((constructor));
void xamarin_initialize_callbacks ()
{
	xamarin_setup = xamarin_setup_impl;
	xamarin_register_assemblies = xamarin_register_assemblies_impl;
	xamarin_register_modules = xamarin_register_modules_impl;
}
