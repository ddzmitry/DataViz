
Public Sub ImportTextFile()
'setup variables
    Dim TextFile As Workbook
    Dim OpenFiles() As Variant
    Dim i As Integer
    'openfiles
    OpenFiles = Application.GetOpenFilename(Title:="Select file(s) to import", MultiSelect:=True)
    'Take off screen flicker
    Application.ScreenUpdating = False
    ' once we got files we can loop over them
    For i = 1 To Application.CountA(OpenFiles)
    'open each file
        Set TextFile = Workbooks.Open(OpenFiles(i))
        
        TextFile.Sheets(1).Range("A1").CurrentRegion.Copy
        Workbooks(1).Activate
        Workbooks(1).Worksheets.Add
        ActiveSheet.Paste
        ActiveSheet.Name = TextFile.Name
        Application.CutCopyMode = False
        
        TextFile.Close
        
    Next i
    Application.ScreenUpdating = True
End Sub
