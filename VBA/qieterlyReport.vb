Public Sub AutoSum()

    Dim lastCell As String
    
    Range("F2").Select
    ' go down to get all cells that have data
    Selection.End(xlDown).Select
    lastCell = ActiveCell.Address
    ' Offset one will get us last empty cell
    ActiveCell.Offset(1, 0).Select
    ' Here we can grab last sell and write sum formula in
    ActiveCell.Value = "=SUM(F2:" + lastCell + ")"
    ' and make it stylish
    ActiveCell.Font.Bold = True
End Sub

Sub AddHeaders()
'
' AddHeaders Macro
'
'
    Rows("1:1").Select
    Selection.Insert Shift:=xlDown
    ActiveWindow.SmallScroll Down:=-3
    Range("A1").Select
    ActiveCell.FormulaR1C1 = "Division"
    Range("B1").Select
    ActiveCell.FormulaR1C1 = "Category"
    Range("C1").Select
    ActiveCell.FormulaR1C1 = "Jan"
    Range("D1").Select
    ActiveCell.FormulaR1C1 = "Feb"
    Range("E1").Select
    ActiveCell.FormulaR1C1 = "Mar"
    Range("F1").Select
    ActiveCell.FormulaR1C1 = "Total Expense"
    Range("A2").Select
End Sub

Sub FormatData()
'
' FormatData Macro
'

'
    Range("A1:F1").Select
    With Selection.Interior
        .Pattern = xlSolid
        .PatternColorIndex = xlAutomatic
        .ThemeColor = xlThemeColorAccent1
        .TintAndShade = -0.249977111117893
        .PatternTintAndShade = 0
    End With
    With Selection.Font
        .ThemeColor = xlThemeColorDark1
        .TintAndShade = 0
    End With
    Selection.Font.Bold = True
    Selection.Borders(xlDiagonalDown).LineStyle = xlNone
    Selection.Borders(xlDiagonalUp).LineStyle = xlNone
    Selection.Borders(xlEdgeLeft).LineStyle = xlNone
    Selection.Borders(xlEdgeTop).LineStyle = xlNone
    With Selection.Borders(xlEdgeBottom)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlMedium
    End With
    Selection.Borders(xlEdgeRight).LineStyle = xlNone
    Selection.Borders(xlInsideVertical).LineStyle = xlNone
    Selection.Borders(xlInsideHorizontal).LineStyle = xlNone
    Range("C2").Select
    Range(Selection, Selection.End(xlDown)).Select
    Range(Selection, Selection.End(xlToRight)).Select
    Selection.Style = "Currency"
    Range("A2").Select
End Sub

Public Sub Final()
    'Make sure to define an index
    Dim i As Integer
    'removing last one to keep of final report
    For i = 1 To Worksheets.Count - 1
    'File Our Macros here
        Worksheets(i).Select
        AutoSum
        AddHeaders
        FormatData
    'copy data
        Range("A2").Select
        Selection.CurrentRegion.Select
        Selection.Copy
    
        Worksheets("Yearly Report").Select
        Range("A30000").Select
    'find empty rpw or data
        Selection.End(xlUp).Select
    'make an offset for 3 rows to make it pretty
        ActiveCell.Offset(3, 0).Select
        ActiveSheet.Paste
    
    Next i
    
End Sub