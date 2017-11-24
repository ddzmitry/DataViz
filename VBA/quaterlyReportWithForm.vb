Private Sub cboWhichSheets_Change()
'dropdown change should prompt user to the sheet
'get chosen value of spreadsheet
    Worksheets(Me.cboWhichSheets.Value).Select
    
End Sub

Private Sub cmdAddWorksheet_Click()
'add worksheet button
' add before first worksheet in the workbook

    Worksheets.Add before:=Worksheets(1)
    'and then add the name for the new sheet
    ActiveSheet.Name = InputBox("Enter the new sheet name")
    'add new item to the active sheet
    Me.cboWhichSheets.AddItem (ActiveSheet.Name)
    
End Sub

Private Sub cmdCreateReport_Click()
' now we need to run all reports function here
    FinalReport
End Sub

Private Sub UserForm_Initialize()
'when form initialized do what?
    Dim i As Integer
    
    For i = 1 To Worksheets.Count
    'select worksheet
        Worksheets(i).Select
        'me will define form itself
        Me.cboWhichSheets.AddItem (Worksheets(i).Name)
           
    Next i
    
    
End Sub