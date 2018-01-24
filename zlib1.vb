Imports System.Runtime.InteropServices
Imports System.IO
Imports Db_Xbox_editor

Public Class zlib1

    <DllImport("zlib1.dll", EntryPoint:="compress2", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.Cdecl)> _
    Friend Shared Function compress2(ByVal dest As Byte(), ByRef destLen As Integer, ByVal src As Byte(), ByVal srcLen As Integer, ByVal level As Integer) As Integer

    End Function

    <DllImport("zlib1.dll", EntryPoint:="uncompress", CallingConvention:=CallingConvention.Cdecl)> _
    Friend Shared Function UncompressByteArray(ByVal dest As Byte(), ByRef destLen As Integer, ByVal src As Byte(), ByVal srcLen As Integer) As Integer

    End Function

    Public Shared Sub unzlibconsole(ByVal stream As FileStream, ByVal archivo As String)

        Dim Leer As New BinaryReader(stream)
        Dim CompressLen As UInt32
        Dim DecompressLen As UInt32

        Leer.BaseStream.Position = 8
        CompressLen = Leer.ReadUInt32
        CompressLen = swaps.swap32(CompressLen)

        Leer.BaseStream.Position = 12
        DecompressLen = Leer.ReadUInt32
        DecompressLen = swaps.swap32(DecompressLen)

        Dim DecompressBuf(0 To (DecompressLen - 1)) As Byte
        Dim CompressBuf(0 To (CompressLen - 1)) As Byte

        Leer.BaseStream.Position = 16
        CompressBuf = Leer.ReadBytes(CompressLen)
        Dim RetVal As UInt32 = zlib1.UncompressByteArray(DecompressBuf, DecompressLen, CompressBuf, CompressLen)

        If (RetVal = &H0) Then

            Dim filename As String = Path.GetFullPath(archivo) + ".unzlib"
            If File.Exists(filename) Then
                System.IO.File.Delete(filename)

            End If


            Dim file_unzlib = New FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            file_unzlib.Write(DecompressBuf, 0, DecompressLen)
            file_unzlib.Close()
            Leer.Close()

        Else
            MsgBox("Zlib File seems to be corrupt")

        End If



    End Sub

    Public Shared Sub unzlibpc(ByVal stream As FileStream, ByVal archivo As String)

        Dim Leer As New BinaryReader(stream)
        Dim CompressLen As UInt32
        Dim DecompressLen As UInt32

        Leer.BaseStream.Position = 8
        CompressLen = Leer.ReadUInt32

        Leer.BaseStream.Position = 12
        DecompressLen = Leer.ReadUInt32

        Dim DecompressBuf(0 To (DecompressLen - 1)) As Byte
        Dim CompressBuf(0 To (CompressLen - 1)) As Byte

        Leer.BaseStream.Position = 16
        CompressBuf = Leer.ReadBytes(CompressLen)
        Dim RetVal As UInt32 = zlib1.UncompressByteArray(DecompressBuf, DecompressLen, CompressBuf, CompressLen)

        If (RetVal = &H0) Then

            Dim filename As String = Path.GetFullPath(archivo) + ".unzlib"
            If File.Exists(filename) Then
                System.IO.File.Delete(filename)

            End If
            Dim file_unzlib = New FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            file_unzlib.Write(DecompressBuf, 0, DecompressLen)
            file_unzlib.Close()
            Leer.Close()

        Else
            MsgBox("Zlib File seems to be corrupt")
        End If



    End Sub

    Public Shared Function unzlibconsole_to_MemStream(ByVal stream As FileStream) As MemoryStream


        Dim Leer As New BinaryReader(stream)
        Dim CompressLen As UInt32
        Dim DecompressLen As UInt32

        Leer.BaseStream.Position = 8
        CompressLen = Leer.ReadUInt32
        CompressLen = swaps.swap32(CompressLen)

        Leer.BaseStream.Position = 12
        DecompressLen = Leer.ReadUInt32
        DecompressLen = swaps.swap32(DecompressLen)

        Dim DecompressBuf(0 To (DecompressLen - 1)) As Byte
        Dim CompressBuf(0 To (CompressLen - 1)) As Byte

        Leer.BaseStream.Position = 16
        CompressBuf = Leer.ReadBytes(CompressLen)
        Try
            Dim RetVal As UInt32 = zlib1.UncompressByteArray(DecompressBuf, DecompressLen, CompressBuf, CompressLen)

            If (RetVal = &H0) Then
                Dim unzlibconsole_to_MemStream_value As New MemoryStream

                unzlibconsole_to_MemStream_value.Write(DecompressBuf, 0, DecompressLen)
                stream.Close()
                Leer.Close()
                Return unzlibconsole_to_MemStream_value
                unzlibconsole_to_MemStream_value.Close()

            End If
        Catch Ex As Exception
            MsgBox("Zlib File seems to be corrupt" & Ex.ToString)

        End Try



    End Function

    Public Shared Function unzlibPc_to_Memstream(ByVal stream As FileStream) As MemoryStream

        Dim Leer As New BinaryReader(stream)
        Dim CompressLen As UInt32
        Dim DecompressLen As UInt32
        Dim unzlibPc_to_MemStream_value As New MemoryStream
        Leer.BaseStream.Position = 8
        CompressLen = Leer.ReadUInt32

        Leer.BaseStream.Position = 12
        DecompressLen = Leer.ReadUInt32

        Dim DecompressBuf(0 To (DecompressLen - 1)) As Byte
        Dim CompressBuf(0 To (CompressLen - 1)) As Byte

        Leer.BaseStream.Position = 16
        CompressBuf = Leer.ReadBytes(CompressLen)
        Try
            Dim RetVal As UInt32 = zlib1.UncompressByteArray(DecompressBuf, DecompressLen, CompressBuf, CompressLen)

            If (RetVal = &H0) Then


                unzlibPc_to_MemStream_value.Write(DecompressBuf, 0, DecompressLen)
                stream.Close()
                Leer.Close()
                Return unzlibPc_to_MemStream_value
                unzlibPc_to_MemStream_value.Close()
            End If
        Catch Ex As Exception
            MsgBox("Zlib File seems to be corrupt" & Ex.ToString)
            stream.Close()
            Leer.Close()
            Return unzlibPc_to_MemStream_value


        End Try


    End Function

    Public Shared Sub zlib_memstream_to_pc(ByRef Stream As MemoryStream, ByVal archivo As String)

        Stream.Position = 0

        Dim src As Byte() = New Byte(Stream.Length) {}
        Stream.Read(src, 0, Stream.Length)

        Try



            Dim Destlen As UInt32 = Stream.Length * 2
            Dim Dest(0 To Destlen) As Byte
            Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, Stream.Length, 9)
            If (Retval = 0) Then
                Dim Filename As String = Path.GetFileName(archivo)
                Dim converted_folder As String = Path.GetDirectoryName(archivo) + "\Converted to Pc\"

                If (Not System.IO.Directory.Exists(converted_folder)) Then
                    System.IO.Directory.CreateDirectory(converted_folder)
                End If
                If File.Exists(Path.GetDirectoryName(archivo) + "\Converted to Pc\" + Filename) Then
                    System.IO.File.Delete(Path.GetDirectoryName(archivo) + "\Converted to Pc\" + Filename)
                End If

                Dim file_zlib = New FileStream(Path.GetDirectoryName(archivo) + "\Converted to Pc\" + Filename, FileMode.OpenOrCreate, FileAccess.Write)
                Dim Grabar As New BinaryWriter(file_zlib)
                If Form1.Tipo_consola = 0 Then
                    file_zlib.WriteByte(&H0)
                ElseIf Form1.Tipo_consola = 4 Then
                    file_zlib.WriteByte(&H4)
                Else
                    MsgBox("Pc not detected sorry. Link on Evo Web this error please")

                End If
                file_zlib.WriteByte(&H4)
                file_zlib.WriteByte(&H10)
                file_zlib.WriteByte(&H81)
                Grabar.Write("WESYS", 0, 5)
                'Destlen = swap32(Destlen)
                Dim uncomp_length As UInt32 = Stream.Length
                Grabar.Write(Destlen)
                'Destlen = swap32(Destlen)
                Grabar.Write(uncomp_length)
                Grabar.Write(Dest, 0, Destlen)
                file_zlib.Close()
                Grabar.Close()
                Stream.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Shared Sub zlib_memstream_to_console(ByVal stream As MemoryStream, ByVal archivo As String)

        stream.Position = 0

        Dim src As Byte() = New Byte(stream.Length) {}
        stream.Read(src, 0, stream.Length)

        Try


            Dim Destlen As UInt32 = stream.Length * 2
            Dim Dest(0 To Destlen) As Byte
            Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, stream.Length, 9)
            If (Retval = 0) Then
                Dim Filename As String = Path.GetFileName(archivo)
                Dim converted_folder As String = Path.GetDirectoryName(archivo) + "\Converted to Console\"

                If (Not System.IO.Directory.Exists(converted_folder)) Then
                    System.IO.Directory.CreateDirectory(converted_folder)
                End If
                If File.Exists(Path.GetDirectoryName(archivo) + "\Converted to Console\" + Filename) Then
                    System.IO.File.Delete(Path.GetDirectoryName(archivo) + "\Converted to Console\" + Filename)
                End If


                Dim file_zlib = New FileStream(Path.GetDirectoryName(archivo) + "\Converted to Console\" + Filename, FileMode.OpenOrCreate, FileAccess.Write)
                Dim Grabar As New BinaryWriter(file_zlib)
                If Form1.Tipo_consola = 1 Then
                    file_zlib.WriteByte(&H1)
                ElseIf Form1.Tipo_consola = 2 Then
                    file_zlib.WriteByte(&H2)
                Else
                    MsgBox("Console not detected sorry. Link on Evo Web this error please")
                    file_zlib.WriteByte(&H1)
                End If

                file_zlib.WriteByte(&H10)
                file_zlib.WriteByte(&H81)
                Grabar.Write("WESYS", 0, 5)
                Destlen = swaps.swap32(Destlen)
                Dim uncomp_length As UInt32 = swaps.swap32(stream.Length)
                Grabar.Write(Destlen)
                Destlen = swaps.swap32(Destlen)
                Grabar.Write(uncomp_length)
                Grabar.Write(Dest, 0, Destlen)
                file_zlib.Close()
                Grabar.Close()
                stream.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Shared Sub zlib_memstream_to_pc_overwriting(ByRef Stream As MemoryStream, ByVal archivo As String)

        Stream.Position = 0

        Dim src As Byte() = New Byte(Stream.Length) {}
        Stream.Read(src, 0, Stream.Length)

        Try



            Dim Destlen As UInt32 = Stream.Length * 2
            Dim Dest(0 To Destlen) As Byte
            Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, Stream.Length, 9)
            If (Retval = 0) Then

                If File.Exists(archivo) Then
                    System.IO.File.Delete(archivo)
                End If

                Dim file_zlib = New FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write)
                Dim Grabar As New BinaryWriter(file_zlib)
                If Form1.Tipo_consola = 0 Then
                    file_zlib.WriteByte(&H0)
                ElseIf Form1.Tipo_consola = 4 Then
                    file_zlib.WriteByte(&H4)
                Else
                    MsgBox("Pc not detected sorry. Link on Evo Web this error please")

                End If
                file_zlib.WriteByte(&H10)
                file_zlib.WriteByte(&H81)
                Grabar.Write("WESYS", 0, 5)
                'Destlen = swap32(Destlen)
                Dim uncomp_length As UInt32 = Stream.Length
                Grabar.Write(Destlen)
                'Destlen = swap32(Destlen)
                Grabar.Write(uncomp_length)
                Grabar.Write(Dest, 0, Destlen)
                file_zlib.Close()
                Grabar.Close()
                Stream.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Shared Sub zlib_memstream_to_console_overwriting(ByVal stream As MemoryStream, ByVal archivo As String)

        stream.Position = 0

        Dim src As Byte() = New Byte(stream.Length) {}
        stream.Read(src, 0, stream.Length)

        Try


            Dim Destlen As UInt32 = stream.Length * 2
            Dim Dest(0 To Destlen) As Byte
            Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, stream.Length, 9)
            If (Retval = 0) Then

                If File.Exists(archivo) Then
                    System.IO.File.Delete(archivo)
                End If


                Dim file_zlib = New FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write)
                Dim Grabar As New BinaryWriter(file_zlib)

                If Form1.Tipo_consola = 2 Then
                    file_zlib.WriteByte(&H2)
                Else
                    file_zlib.WriteByte(&H1)
                End If

                file_zlib.WriteByte(&H10)
                file_zlib.WriteByte(&H81)
                Grabar.Write("WESYS", 0, 5)
                Destlen = swaps.swap32(Destlen)
                Dim uncomp_length As UInt32 = swaps.swap32(stream.Length)
                Grabar.Write(Destlen)
                Destlen = swaps.swap32(Destlen)
                Grabar.Write(uncomp_length)
                Grabar.Write(Dest, 0, Destlen)
                file_zlib.Close()
                Grabar.Close()
                stream.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



End Class
