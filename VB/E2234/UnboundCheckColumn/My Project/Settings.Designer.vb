﻿' Developer Express Code Central Example:
' DXGrid - How to embed the ChartControl into the GridControl cell
' 
' It's necessary to implement the CellTemplate with the ChartControl, and bind any
' ChartControl property to a cell value, for example. In the sample, the first
' SeriesPoint in the Points collection is bound to a value in the cell
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2234

' Developer Express Code Central Example:
' DXGrid - How to embed the ChartControl into the GridControl cell
' 
' It's necessary to implement the CellTemplate with the ChartControl, and bind any
' ChartControl property to a cell value, for example. In the sample, the first
' SeriesPoint in the Points collection is bound to a value in the cell
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2234

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3082
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Namespace My


    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")> _
    Friend NotInheritable Partial Class Settings
        Inherits System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Settings = (CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()), Settings))

        Public Shared ReadOnly Property [Default]() As Settings
            Get
                Return defaultInstance
            End Get
        End Property
    End Class
End Namespace
