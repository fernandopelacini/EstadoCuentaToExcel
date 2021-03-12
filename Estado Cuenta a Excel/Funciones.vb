Imports System.Management
Imports System.Security.Cryptography
Imports System.Text

Module Funciones
  
    Public BaseDatos As String
    'Public BaseDatosLocal As String
    Public Servidor As String
    Public Password As String
    Public UserBD As String
    Public UsuarioLogin As String
    Public UsuarioNivel As String
    'Public intIdGrupoUsuario As Integer
    'Public PathReportes As String = Application.StartupPath & "\Reportes"
    Public erpError As New ErrorProvider
    Public SeparadorDecimal As Char
    Public formatoLectura As String = Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
    Public formatoEscritura As String = "yyyyMMdd"
    Public conexion As clsSQLDataManagement = New clsSQLDataManagement(clsSQLDataManagement.Providers.SQL, Servidor, BaseDatos, UserBD, Password)

    Private strClave As String = "%ü&/@#$A"
    Private des As New TripleDESCryptoServiceProvider 'Algorithmo TripleDES
    Private hashmd5 As New MD5CryptoServiceProvider 'objeto md5


    Public Function Encriptar(ByVal strPass As String) As String

        Dim i As Integer
        Dim strPass2 As String
        Dim strCAR As String, strCodigo As String

        strPass2 = ""

        For i = 1 To Len(strPass)
            strCAR = Mid(strPass, i, 1)
            strCodigo = Mid(strClave, ((i - 1) Mod Len(strClave)) + 1, 1)
            strPass2 = strPass2 & Right("0" & Hex(Asc(strCodigo) Xor Asc(strCAR)), 2)
        Next i
        Encriptar = strPass2
    End Function

    Public Function Desencriptar(ByVal strPass As String) As String

        Dim i As Integer
        Dim strPass2 As String
        Dim strCAR As String, strCodigo As String
        Dim j As Integer

        strPass2 = ""
        j = 1
        For i = 1 To Len(strPass) Step 2
            strCAR = Mid(strPass, i, 2)
            strCodigo = Mid(strClave, ((j - 1) Mod Len(strClave)) + 1, 1)
            strPass2 = strPass2 & Chr(Asc(strCodigo) Xor Val("&h" + strCAR))
            j = j + 1
        Next i
        Desencriptar = strPass2
    End Function

    Public Function DecimalSeparator() As Char
        DecimalSeparator = Mid$(1 / 2, 2, 1)
    End Function

    ''' <summary>
    ''' Setea el mensaje de error a un control atraves del objeto ErrorProvider
    ''' </summary>
    ''' <param name="oControl">Control al que se le aplica el mensaje de error.
    ''' Eg: TextBox1, ComboBox1</param>
    ''' <param name="strMensaje">Mensaje de error a mostrar en el control</param>
    ''' <remarks></remarks>
    Public Sub SetError(ByVal oControl As Control, ByVal strMensaje As String, ByVal oColor As System.Drawing.Color)
        erpError.Clear()
        erpError.SetError(oControl, strMensaje)
        oControl.BackColor = oColor '  Color.Yellow
    End Sub

    Public Sub LimpiarError(ByVal oControl As Control)
        erpError.Clear()
        oControl.BackColor = Color.White
    End Sub

    ''' <summary>
    ''' Obtiene la fecha del servidor de base de datos.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetServerDate() As Date
        Dim oReader As OleDb.OleDbDataReader
        Dim dteFecha As DateTime

        Try
            oReader = conexion.ExecuteQuery("SELECT GETDATE()")

            oReader.Read()
            dteFecha = Format(CDate(oReader(0)), formatoLectura)
            oReader.Close()

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            dteFecha = Today

        End Try
        oReader = Nothing
        Return dteFecha
    End Function

    ''' <summary>
    ''' Valida que el caracter ingresado solo sea nro o el separador decimal.
    ''' </summary>
    ''' <param name="chrCaracter">Caracter ingresado por el usuario.</param>
    ''' <param name="txtTextbox">Textbox donde tipeo el usuario</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SoloNumeros(ByVal chrCaracter As System.Windows.Forms.KeyPressEventArgs, _
                                ByVal txtTextbox As TextBox, _
                                      Optional ByVal blnAceptaNegativos As Boolean = False) As Boolean
        If Char.IsDigit(chrCaracter.KeyChar) Then
            Return False
        ElseIf Char.IsControl(chrCaracter.KeyChar) Then
            Return False ' e.Handled = False
        ElseIf chrCaracter.KeyChar = SeparadorDecimal And Not txtTextbox.Text.IndexOf(SeparadorDecimal) = -1 Then
            Return True
        ElseIf chrCaracter.KeyChar = SeparadorDecimal Then
            Return False
        ElseIf blnAceptaNegativos And Char.IsSymbol(chrCaracter.KeyChar) Then
            Return False
        Else
            Return True
        End If
        Return True
    End Function

    'Public Function SoloNumeros(ByVal chrCaracter As System.Windows.Forms.KeyPressEventArgs) As Boolean
    '    If Char.IsDigit(chrCaracter.KeyChar) Then
    '        Return False
    '    ElseIf Char.IsControl(chrCaracter.KeyChar) Then
    '        Return False ' e.Handled = False
    '    ElseIf chrCaracter.KeyChar = SeparadorDecimal And Not chrCaracter.ToString().IndexOf(SeparadorDecimal) = -1 Then
    '        'SHITTTTT
    '        Return True
    '    ElseIf chrCaracter.KeyChar = SeparadorDecimal Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    '    Return True
    'End Function


    ''' <summary>
    ''' Encripta los datos para generar la licencia utilizando MD5
    ''' </summary>
    ''' <param name="strPass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EncriptarMD5(ByVal strPass As String) As String
        Dim strEncriptada As String
        des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(strClave))
        des.Mode = CipherMode.ECB
        Dim encrypt As ICryptoTransform = des.CreateEncryptor()
        Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(strPass)
        strEncriptada = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
        Return strEncriptada
    End Function
    Public Function DesencriptarMD5(ByVal strPass As String) As String
        Dim strDesencriptada As String

        des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(strClave))
        des.Mode = CipherMode.ECB
        Dim desencrypta As ICryptoTransform = des.CreateDecryptor()
        Dim buff() As Byte = Convert.FromBase64String(strPass)
        strDesencriptada = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length))
        Return strDesencriptada
    End Function


    ''' <summary>
    ''' Funcion que valida cuit
    ''' </summary>
    ''' <param name="strNroCuit">cuit a verificar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarCUIT(ByVal strNroCuit As String) As Boolean
        Dim mk_suma As Integer
        Dim mk_valido As String

        If IsNumeric(strNroCuit) Then
            If strNroCuit.Length <> 11 Then
                mk_valido = False
            Else
                mk_suma = 0
                mk_suma += CInt(strNroCuit.Substring(0, 1)) * 5
                mk_suma += CInt(strNroCuit.Substring(1, 1)) * 4
                mk_suma += CInt(strNroCuit.Substring(2, 1)) * 3
                mk_suma += CInt(strNroCuit.Substring(3, 1)) * 2
                mk_suma += CInt(strNroCuit.Substring(4, 1)) * 7
                mk_suma += CInt(strNroCuit.Substring(5, 1)) * 6
                mk_suma += CInt(strNroCuit.Substring(6, 1)) * 5
                mk_suma += CInt(strNroCuit.Substring(7, 1)) * 4
                mk_suma += CInt(strNroCuit.Substring(8, 1)) * 3
                mk_suma += CInt(strNroCuit.Substring(9, 1)) * 2
                mk_suma += CInt(strNroCuit.Substring(10, 1)) * 1
      
                If Math.Round(mk_suma / 11, 0) = (mk_suma / 11) Then
                    mk_valido = True
                Else
                    mk_valido = False
                End If
            End If
        Else
            mk_valido = False
        End If
        Return (mk_valido)
    End Function
    ' ''' <summary>
    ' ''' Escribe en el log de la aplicación.
    ' ''' El mismo se encuentra en el directorio de instalacion con el nombre de Grupo Harmony.log
    ' ''' </summary>
    ' ''' <param name="strMensaje">Mensaje a grabar en el log</param>
    ' ''' <param name="strModulo">Clase y metodo en el que se registra la acción.</param>
    ' ''' <param name="dgnSeveridad" >Tipo de log:
    ' ''' Critical = 1 (Fatal error or applicaiton crash)
    ' ''' Error = 2 (Recoverable error)
    ' ''' Information = 3 (Informational message)
    ' ''' Warning = 4 (Non critical problem)
    ' ''' Verbose = 16 (Debugging trace)
    ' ''' Start = 256 (Starting of a logical operation)
    ' ''' Stop = 512 (Stopping of a logical operation)
    ' ''' Suspend = 1024 (Suspension of a logical operation)
    ' ''' Resume = 2048 (Resumption of a logical operation)
    ' ''' Transfer = 4096 (Changing of correlation identity)
    ' ''' </param>
    ' ''' <remarks></remarks>
    'Public Sub LogGPM(ByVal strMensaje As String, _
    '               ByVal strModulo As String, _
    '               ByVal dgnSeveridad As Diagnostics.TraceEventType)

    '    Dim strLog As System.Text.StringBuilder
    '    strLog = New System.Text.StringBuilder()

    '    strLog.Append(Now.ToString)
    '    strLog.Append("- ")
    '    strLog.Append(strMensaje)
    '    strLog.Append("- ")
    '    strLog.Append(strModulo)
    '    My.Application.Log.WriteEntry(strLog.ToString, dgnSeveridad)

    '    strLog = Nothing

    'End Sub
    'Public Sub ConfigurarForm(ByVal frm As Form)
    '    ' frm.Font = gstrtipoFuente
    '    'frm.ForeColor = gstrcolorLetra
    '    'frm.BackColor = gstrcolorFondo
    'End Sub

    ''------------------------------------------------------------------------------
    '' Clase para manejar ficheros INIs
    '' Permite leer secciones enteras y todas las secciones de un fichero INI
    ''--------------------------------------------------------------------------
    'Public Class cIniArray
    '    Private sBuffer As String ' Para usarla en las funciones GetSection(s)

    '    '--- Declaraciones para leer ficheros INI ---
    '    ' Leer todas las secciones de un fichero INI, esto seguramente no funciona en Win95
    '    ' Esta función no estaba en las declaraciones del API que se incluye con el VB
    '    Private Declare Function GetPrivateProfileSectionNames Lib "kernel32" Alias "GetPrivateProfileSectionNamesA" (ByVal lpszReturnBuffer As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '    ' Leer una sección completa
    '    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '    ' Leer una clave de un fichero INI
    '    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '    ' Escribir una clave de un fichero INI (también para borrar claves y secciones)
    '    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    '    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
    '    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer
    '    Public Sub IniDeleteKey(ByVal sIniFile As String, ByVal sSection As String, Optional ByVal sKey As String = "")
    '        '--------------------------------------------------------------------------
    '        ' Borrar una clave o entrada de un fichero INI                  (16/Feb/99)
    '        ' Si no se indica sKey, se borrará la sección indicada en sSection
    '        ' En otro caso, se supone que es la entrada (clave) lo que se quiere borrar
    '        '
    '        ' Para borrar una sección se debería usar IniDeleteSection
    '        '
    '        If Len(sKey) = 0 Then
    '            ' Borrar una sección
    '            Call WritePrivateProfileString(sSection, 0, 0, sIniFile)
    '        Else
    '            ' Borrar una entrada
    '            Call WritePrivateProfileString(sSection, sKey, 0, sIniFile)
    '        End If
    '    End Sub
    '    Public Sub IniDeleteSection(ByVal sIniFile As String, ByVal sSection As String)
    '        '--------------------------------------------------------------------------
    '        ' Borrar una sección de un fichero INI                          (04/Abr/01)
    '        ' Borrar una sección
    '        Call WritePrivateProfileString(sSection, 0, 0, sIniFile)
    '    End Sub
    '    Public Function IniGet(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, Optional ByVal sDefault As String = "") As String
    '        '--------------------------------------------------------------------------
    '        ' Devuelve el valor de una clave de un fichero INI
    '        ' Los parámetros son:
    '        '   sFileName   El fichero INI
    '        '   sSection    La sección de la que se quiere leer
    '        '   sKeyName    Clave
    '        '   sDefault    Valor opcional que devolverá si no se encuentra la clave
    '        '--------------------------------------------------------------------------
    '        Dim ret As Integer
    '        Dim sRetVal As String
    '        '
    '        sRetVal = New String(Chr(0), 255)
    '        '
    '        ret = GetPrivateProfileString(sSection, sKeyName, sDefault, sRetVal, Len(sRetVal), sFileName)
    '        If ret = 0 Then
    '            Return sDefault
    '        Else
    '            Return Left(sRetVal, ret)
    '        End If
    '    End Function

    '    Public Sub IniWrite(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, ByVal sValue As String)
    '        '--------------------------------------------------------------------------
    '        ' Guarda los datos de configuración
    '        ' Los parámetros son los mismos que en LeerIni
    '        ' Siendo sValue el valor a guardar
    '        '
    '        Call WritePrivateProfileString(sSection, sKeyName, sValue, sFileName)
    '    End Sub
    '    Public Function IniGetSection(ByVal sFileName As String, ByVal sSection As String) As String()
    '        '--------------------------------------------------------------------------
    '        ' Lee una sección entera de un fichero INI                      (27/Feb/99)
    '        ' Adaptada para devolver un array de string                     (04/Abr/01)
    '        '
    '        ' Esta función devolverá un array de índice cero
    '        ' con las claves y valores de la sección
    '        '
    '        ' Parámetros de entrada:
    '        '   sFileName   Nombre del fichero INI
    '        '   sSection    Nombre de la sección a leer
    '        ' Devuelve:
    '        '   Un array con el nombre de la clave y el valor
    '        '   Para leer los datos:
    '        '       For i = 0 To UBound(elArray) -1 Step 2
    '        '           sClave = elArray(i)
    '        '           sValor = elArray(i+1)
    '        '       Next
    '        '
    '        Dim aSeccion() As String
    '        Dim n As Integer
    '        '
    '        ReDim aSeccion(0)
    '        '
    '        ' El tamaño máximo para Windows 95
    '        sBuffer = New String(ChrW(0), 32767)
    '        '
    '        n = GetPrivateProfileSection(sSection, sBuffer, sBuffer.Length, sFileName)
    '        '
    '        If n > 0 Then
    '            '
    '            ' Cortar la cadena al número de caracteres devueltos
    '            ' menos los dos últimos que indican el final de la cadena
    '            sBuffer = sBuffer.Substring(0, n - 2).TrimEnd()
    '            ' Cada elemento estará separado por un Chr(0)
    '            ' y cada valor estará en la forma: clave = valor
    '            aSeccion = sBuffer.Split(New Char() {ChrW(0), "="c})
    '        End If
    '        ' Devolver el array
    '        Return aSeccion
    '    End Function
    '    Public Function IniGetSections(ByVal sFileName As String) As String()
    '        '--------------------------------------------------------------------------
    '        ' Devuelve todas las secciones de un fichero INI                (27/Feb/99)
    '        ' Adaptada para devolver un array de string                     (04/Abr/01)
    '        '
    '        ' Esta función devolverá un array con todas las secciones del fichero
    '        '
    '        ' Parámetros de entrada:
    '        '   sFileName   Nombre del fichero INI
    '        ' Devuelve:
    '        '   Un array con todos los nombres de las secciones
    '        '   La primera sección estará en el elemento 1,
    '        '   por tanto, si el array contiene cero elementos es que no hay secciones
    '        '
    '        Dim n As Integer
    '        Dim aSections() As String
    '        '
    '        ReDim aSections(0)
    '        '
    '        ' El tamaño máximo para Windows 95
    '        sBuffer = New String(ChrW(0), 32767)
    '        '
    '        ' Esta función del API no está definida en el fichero TXT
    '        n = GetPrivateProfileSectionNames(sBuffer, sBuffer.Length, sFileName)
    '        '
    '        If n > 0 Then
    '            ' Cortar la cadena al número de caracteres devueltos
    '            ' menos los dos últimos que indican el final de la cadena
    '            sBuffer = sBuffer.Substring(0, n - 2).TrimEnd()
    '            aSections = sBuffer.Split(ChrW(0))
    '        End If
    '        ' Devolver el array
    '        Return aSections
    '    End Function
    '    '
    '    '        Public Shared Function AppPath( _
    '    '                Optional ByVal backSlash As Boolean = False _
    '    '                ) As String
    '    '            ' System.Reflection.Assembly.GetExecutingAssembly...
    '    '            Dim s As String = _
    '    '                IO.Path.GetDirectoryName( _
    '    '                System.Reflection.Assembly.GetExecutingAssembly.GetCallingAssembly.Location)
    '    '            ' si hay que añadirle el backslash
    '    '            If backSlash Then
    '    '                s &= "\"
    '    '            End If
    '    '            Return s
    '    '        End Function

    'End Class




    Public Function EsAdministrador() As Boolean
        If Strings.InStr(UsuarioNivel, "Admin", CompareMethod.Text) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

  


    '****************************************
    'Desarrollado por: Pedro Alex Taya Yactayo
    'Email: alextaya@hotmail.com
    'Web: http://es.geocities.com/wiseman_alextaya
    '     http://groups.msn.com/mugcanete
    '****************************************

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = String.Empty
        Dim entero As String = String.Empty
        Dim dec As String = String.Empty
        Dim flag As String = String.Empty

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = SeparadorDecimal Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

    Public Function GetUnixTimestamp() As String
        Return Left((DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString(), 10)
    End Function
End Module
