Imports System.IO
Imports Db_Xbox_editor





Public Class swaps

    Public Shared Function swap32(ByVal value As UInt32) As UInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Dim bytes As Byte() = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            value = BitConverter.ToUInt32(bytes, 0)
        End If

        Return value

    End Function
    Public Shared Function swap16(ByVal value As UInt16) As UInt16
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Dim bytes As Byte() = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            value = BitConverter.ToUInt16(bytes, 0)
        End If

        Return value

    End Function
    Public Shared Function swap16_pcforzado(ByVal value As UInt16) As UInt16
        If Form1.Tipo_consola = 0 Or Form1.Tipo_consola = 4 Then
            Dim bytes As Byte() = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            value = BitConverter.ToUInt16(bytes, 0)
        End If

        Return value

    End Function


    Public Shared Function swap32_SignedInt(ByVal value As Integer) As Integer
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Dim bytes As Byte() = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            value = BitConverter.ToInt32(bytes, 0)
        End If
        Return value

    End Function

    Public Shared Function Reverse_byte(ByVal inv8 As Byte) As Byte

        Dim count As Byte = 7

        Dim reverse_num As Byte = inv8



        inv8 >>= 1

        Do While inv8 <> 0


            reverse_num <<= 1

            reverse_num = reverse_num Or inv8 And 1

            inv8 >>= 1

            count -= 1

        Loop

        reverse_num <<= count
        Return reverse_num
    End Function
    Public Shared Function rotl(ByVal value As Byte, ByVal shift As Integer) As Byte

        If (shift = shift And 1 * 8 - 1) = 0 Then
            Return value
        Else

            Return (value << shift) Or (value >> (1 * 8 - shift))
        End If
    End Function

    Public Shared Function rotr(ByVal value As Byte, ByVal shift As Integer) As Byte

        If (shift = shift And 1 * 8 - 1) = 0 Then
            Return value
        Else

            Return (value >> shift) Or (value << (1 * 8 - shift))
        End If
    End Function
    Public Shared Function Reverse_int16(ByVal inv16 As UInt16) As UInt16
        Dim count As Byte = 15
        Dim reverse_num As UInt16 = inv16

        inv16 >>= 1

        Do While inv16 <> 0

            reverse_num <<= 1

            reverse_num = reverse_num Or inv16 And 1

            inv16 >>= 1

            count -= 1

        Loop
        reverse_num <<= count
        Return reverse_num
    End Function

    Public Shared Function Reverse_int32(ByVal inv32 As UInt32) As UInt32


        Dim count As UInt32 = 31
        Dim reverse_num As UInt32 = inv32

        inv32 >>= 1
        Do While inv32 <> 0
            reverse_num <<= 1
            reverse_num = reverse_num Or inv32 And 1
            inv32 >>= 1
            count -= 1
        Loop
        reverse_num <<= count
        Return reverse_num
    End Function


End Class
