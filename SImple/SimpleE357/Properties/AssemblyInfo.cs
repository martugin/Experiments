using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Office.Tools.Excel;

// Общие сведения об этой сборке предоставляются следующим набором 
// атрибутов. Отредактируйте значения этих атрибутов, чтобы изменить
// общие сведения об этой сборке.
[assembly: AssemblyTitle("SimpleE357")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("SimpleE357")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения False в параметре ComVisible делает типы в этой сборке невидимыми 
// для COM-компонентов. Если необходим доступ к типу в этой сборке из 
// COM, следует установить атрибут ComVisible в TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("cf8115a1-7547-4c60-b91d-5100275aa07e")]

// Сведения о версии сборки состоят из следующих четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии 
//      Номер построения
//      Редакция
//
// Можно задать все значения или принять номер построения и номер редакции по умолчанию, 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// 
// Атрибут ExcelLocale1033 управляет языковым стандартом, передаваемым в
// объектную модель Excel. Задание значения True для ExcelLocale1033 заставляет объектную модель Excel 
// действовать одинаково во всех языковых стандартах, что соответствует функционированию Visual Basic для 
// приложений. Установка ExcelLocale1033 в False заставляет объектную модель Excel
// действовать по-другому, если у пользователей разные языковые настройки, что соответствует 
// функционированию Visual Studio Tools for Office версии 2003. Это может привести к непредвиденным 
// результатам в сведениях, зависящих от языка системы, например в названиях формул и форматах дат.
// 
[assembly: ExcelLocale1033(true)]
