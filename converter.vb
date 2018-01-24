Imports System.IO


Public Class converter

    Public Shared Sub ball(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 140
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        For i = 0 To num_of_blocks - 1
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 138
        Next
    End Sub

    Public Shared Sub BallCondition_topc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream



        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        Dim Auxbyte As Byte

        For i = 0 To num_of_blocks - 1
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)

            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)


            Auxbyte = rotr(br.ReadByte, 2)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Auxbyte)


            br.BaseStream.Position = br.BaseStream.Position + 3


        Next

    End Sub

    Public Shared Sub BallCondition_toconsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream



        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        Dim Auxbyte As Byte

        For i = 0 To num_of_blocks - 1
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)

            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)


            Auxbyte = rotl(br.ReadByte, 2)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Auxbyte)


            br.BaseStream.Position = br.BaseStream.Position + 3


        Next

    End Sub

    Public Shared Sub Boots(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 304
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        For i = 0 To num_of_blocks - 1
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 302
        Next
    End Sub

    Public Shared Sub CompetitionKind_to_pc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 88
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As Byte
        For i = 0 To num_of_blocks - 1
            br.BaseStream.Position = br.BaseStream.Position + 1
            Aux = Byte_comp_kind_to_pc(br.ReadByte)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 86
        Next
    End Sub

    Public Shared Sub CompetitionKind_to_console(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 88
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As Byte
        For i = 0 To num_of_blocks - 1
            br.BaseStream.Position = br.BaseStream.Position + 1
            Aux = Byte_comp_kind_to_console(br.ReadByte)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 86
        Next
    End Sub

    Public Shared Function Byte_comp_kind_to_pc(ByVal value As Byte) As Byte

        Dim aux1 As Byte = 0
        Dim valuecambiado As Byte = 0
        aux1 = value
        aux1 = (aux1 And 3)
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado) 'desplazo el bit de control

        aux1 = value
        aux1 = (aux1 And 28)
        aux1 = aux1 << 1
        valuecambiado = (aux1 Or valuecambiado) 'muevo grupo 4 bits

        aux1 = value
        aux1 = (aux1 And 224)
        aux1 = aux1 >> 5
        valuecambiado = (aux1 Or valuecambiado) 'muevo grupo 3 bits


        Return valuecambiado
    End Function

    Public Shared Function Byte_comp_kind_to_console(ByVal value As Byte) As Byte

        Dim aux1 As Byte = 0
        Dim valuecambiado As Byte = 0
        aux1 = value
        aux1 = (aux1 And 7)
        aux1 = aux1 << 5
        valuecambiado = (aux1 Or valuecambiado) 'desplazo el bit de control

        aux1 = value
        aux1 = (aux1 And 56)
        aux1 = aux1 >> 1
        valuecambiado = (aux1 Or valuecambiado) 'muevo grupo 4 bits

        aux1 = value
        aux1 = (aux1 And 192)
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado) 'muevo grupo 3 bits


        Return valuecambiado
    End Function

    Public Shared Sub InstallVersion_Ball_Boots_Stadium_Dlc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 4
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        For i = 0 To num_of_blocks - 1
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 2
        Next
    End Sub

    Public Shared Sub PlayerAssignment_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 16
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux_int As UInt16
        Dim Aux_int32 As UInt32

        For i = 0 To num_of_blocks - 1
            Aux_int32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_int32)
            Aux_int32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_int32)
            Aux_int32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_int32)

            br.BaseStream.Position = br.BaseStream.Position + 1

            Aux_int = bitworking_PlayerAssignment_toConsole(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux_int)
            br.BaseStream.Position = br.BaseStream.Position + 1

        Next
    End Sub

    Public Shared Sub PlayerAssignment_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 16
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux_int As UInt16
        Dim Aux_int32 As UInt32

        For i = 0 To num_of_blocks - 1
            Aux_int32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_int32)
            Aux_int32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_int32)
            Aux_int32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_int32)

            br.BaseStream.Position = br.BaseStream.Position + 1

            Aux_int = bitworking_PlayerAssignment_toPc(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux_int)
            br.BaseStream.Position = br.BaseStream.Position + 1

        Next
    End Sub

    Public Shared Function bitworking_PlayerAssignment_toConsole(ByVal value As UInt16) As UInt16


        Dim reversed As UInt16 = 0
        'value = swaps.swap16(value)
        reversed = Reverse_int16(value)
        'value = swaps.swap16(value)

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0

        aux1 = reversed
        aux1 = (aux1 And Convert.ToUInt16("1111111111", 2))
        'aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado) 'desplazo el bit de control


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111111", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_PlayerAssignment_toPc(ByVal value As UInt16) As UInt16


        Dim reversed As UInt16 = 0
        value = swaps.swap16(value)
        reversed = Reverse_int16(value)

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0


        aux1 = reversed
        aux1 = (aux1 And Convert.ToUInt16("1111111111000000", 2))
        'aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado) 'desplazo el bit de control


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111110000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


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

    Public Shared Sub SpecialPlayerAssignment(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16 = 0

        Dim Aux_32 As UInt32 = 0

        For i = 0 To num_of_blocks - 1
            Aux_32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux_32)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 2

        Next
    End Sub

    Public Shared Sub SpecialPlayerAssignmentKind(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 136
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As Byte = 0

        For i = 0 To num_of_blocks - 1

            br.BaseStream.Position = br.BaseStream.Position + 1
            Aux = Reverse_byte(br.ReadByte)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 134

        Next
    End Sub

    Public Shared Sub Stadium_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 272
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt32
        Dim Aux_16 As UInt16
        For i = 0 To num_of_blocks - 1

            Aux = bitworking_Stadium_toPc(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux)

            Aux_16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux_16)
            ' Aux_16 = swaps.swap16(br.ReadUInt16)
            ' br.BaseStream.Position = br.BaseStream.Position - 2
            'Grabar.Write(Aux_16)

            br.BaseStream.Position = br.BaseStream.Position + 266
        Next
    End Sub

    Public Shared Function bitworking_Stadium_toPc(ByVal value As UInt32) As UInt32



        value = swaps.swap32(value)

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0




        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111111111111111000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111111000", 2))
        aux1 = aux1 << 17
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("100", 2))
        aux1 = aux1 << 27
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)

        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Stadium_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 272
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt32
        Dim Aux_16 As UInt16
        For i = 0 To num_of_blocks - 1

            Aux = bitworking_Stadium_toConsole(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux)

            'Aux_16 = swaps.swap16(br.ReadUInt16)
            'br.BaseStream.Position = br.BaseStream.Position - 2
            'Grabar.Write(Aux_16)
            Aux_16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux_16)

            br.BaseStream.Position = br.BaseStream.Position + 266
        Next
    End Sub

    Public Shared Function bitworking_Stadium_toConsole(ByVal value As UInt32) As UInt32



        'value = swaps.swap32(value)

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111111111111111", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111100000000000000000000", 2))
        aux1 = aux1 >> 17
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("100000000000000000000000000000", 2))
        aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)

        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub StadiumOrder_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16


        For i = 0 To num_of_blocks - 1

            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)

            Aux = swaps.swap16(br.ReadUInt16)
            Aux = bitworking_StadiumOrder_toPc(Aux)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 2

        Next
    End Sub

    Public Shared Function bitworking_StadiumOrder_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111111000000000", 2))
        aux1 = aux1 >> 1
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("100000000", 2))
        aux1 = aux1 >> 8
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("10000000", 2))
        aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111111", 2))
        aux1 = aux1 << 1
        valuecambiado = (aux1 Or valuecambiado)

        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


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

    Public Shared Function rotl_16(ByVal value As UInt16, ByVal shift As Integer) As UInt16

        If (shift = shift And 2 * 8 - 1) = 0 Then
            Return value
        Else

            Return (value << shift) Or (value >> (2 * 8 - shift))
        End If
    End Function

    Public Shared Function rotr_16(ByVal value As UInt16, ByVal shift As Integer) As UInt16

        If (shift = shift And 2 * 8 - 1) = 0 Then
            Return value
        Else
            Return (value >> shift) Or (value << (2 * 8 - shift))
        End If
    End Function

    Public Shared Sub StadiumOrder_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16


        For i = 0 To num_of_blocks - 1

            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)

            Aux = swaps.swap16(br.ReadUInt16)
            Aux = bitworking_StadiumOrder_toConsole(Aux)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 2

        Next
    End Sub

    Public Shared Function bitworking_StadiumOrder_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11111110", 2))
        aux1 = aux1 >> 1
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1000000000000000", 2))
        aux1 = aux1 >> 8
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1", 2))
        aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111111100000000", 2))
        aux1 = aux1 << 1
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub StadiumOrderInConfederation_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        Dim AuxByte As Byte

        For i = 0 To num_of_blocks - 1

            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 1

            AuxByte = rotr(br.ReadByte, 1)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(AuxByte)
            br.BaseStream.Position = br.BaseStream.Position + 2


        Next
    End Sub

    Public Shared Sub StadiumOrderInConfederation_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 8
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        Dim AuxByte As Byte

        For i = 0 To num_of_blocks - 1

            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 1

            AuxByte = rotl(br.ReadByte, 1)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(AuxByte)
            br.BaseStream.Position = br.BaseStream.Position + 2


        Next
    End Sub

    Public Shared Sub Team_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 1400
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)



            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)



            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Aux32 = bitworking_Team_toPc(Aux32)
            Grabar.Write(Aux32)

            br.BaseStream.Position = br.BaseStream.Position + 1376
        Next
    End Sub

    Public Shared Function bitworking_Team_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'value = swaps.swap16(value)
        Dim reversed As UInt32 = Reverse_int32(value)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111100000000000000000000000", 2))
        aux1 = aux1 >> 23
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11110000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000", 2))
        aux1 = aux1 >> 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = reversed
        aux1 = (aux1 And Convert.ToUInt32("11111111111100000000000000000000", 2))
        'aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Team_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 1400
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)



            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)



            Aux32 = br.ReadUInt32
            br.BaseStream.Position = br.BaseStream.Position - 4
            Aux32 = bitworking_Team_toConsole(Aux32)
            Grabar.Write(Aux32)

            br.BaseStream.Position = br.BaseStream.Position + 1376

        Next
    End Sub

    Public Shared Function bitworking_Team_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'value = swaps.swap16(value)
        Dim reversed As UInt32 = Reverse_int32(value)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111111", 2))
        aux1 = aux1 << 23
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000", 2))
        aux1 = aux1 << 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = reversed
        aux1 = (aux1 And Convert.ToUInt32("111111111111", 2))
        'aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Competition_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 32
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0

        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Aux32 = bitworking_Competition_toPc(Aux32)
            Grabar.Write(Aux32)

            br.BaseStream.Position = br.BaseStream.Position + 28

        Next
    End Sub

    Public Shared Function bitworking_Competition_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'value = swaps.swap16(value)
        Dim reversed As UInt32 = Reverse_int32(value)


        aux1 = reversed
        aux1 = (aux1 And 4278190080)
        aux1 = aux1 >> 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 768)
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1024)
        aux1 = aux1 << 13
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 129024)
        aux1 = aux1 >> 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16646144)
        aux1 = aux1 >> 1
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4278190080)
        'aux1 = aux1 << 7
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Competition_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 32
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0

        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Aux32 = bitworking_Competition_toConsole(Aux32)
            Grabar.Write(Aux32)

            br.BaseStream.Position = br.BaseStream.Position + 28

        Next
    End Sub

    Public Shared Function bitworking_Competition_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'value = swaps.swap16(value)
        Dim reversed As UInt32 = Reverse_int32(value)


        aux1 = reversed
        aux1 = (aux1 And 4278190080)
        aux1 = aux1 >> 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16128)
        aux1 = aux1 << 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 49152)
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 8323072)
        aux1 = aux1 << 1
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 8388608)
        aux1 = aux1 >> 13
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4278190080)
        'aux1 = aux1 << 7
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub CompetitionEntry_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)
            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)
            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            br.BaseStream.Position = br.BaseStream.Position + 2

            Aux16 = swaps.swap16(br.ReadUInt16)
            Aux16 = bitworking_CompetitionEntry_toPc(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)




        Next
    End Sub

    Public Shared Function bitworking_CompetitionEntry_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And 15)
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 496)
        aux1 = aux1 << 3
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 65024)
        aux1 = aux1 >> 9
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub CompetitionEntry_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)
            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)
            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            br.BaseStream.Position = br.BaseStream.Position + 2

            Aux16 = br.ReadUInt16
            Aux16 = bitworking_CompetitionEntry_toConsole(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)




        Next
    End Sub

    Public Shared Function bitworking_CompetitionEntry_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And 127)
        aux1 = aux1 << 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 3968)
        aux1 = aux1 >> 3
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 61440)
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Country_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 1348
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            ' Aux32 = swaps.swap32(br.ReadUInt32)
            ' br.BaseStream.Position = br.BaseStream.Position - 4
            'Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Aux32 = bitworking_Country_toPc(Aux32)
            Grabar.Write(Aux32)


            br.BaseStream.Position = br.BaseStream.Position + 1344

        Next
    End Sub

    Public Shared Function bitworking_Country_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 1)
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 14)
        aux1 = aux1 << 27
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 8176)
        aux1 = aux1 << 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4186112)
        aux1 = aux1 >> 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1069547520)
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 3221225472)
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Country_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 1348
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            'Aux32 = swaps.swap32(br.ReadUInt32)
            'br.BaseStream.Position = br.BaseStream.Position - 4
            'Grabar.Write(Aux32)


            Aux32 = br.ReadUInt32
            br.BaseStream.Position = br.BaseStream.Position - 4
            Aux32 = bitworking_Country_toConsole(Aux32)
            Grabar.Write(Aux32)


            br.BaseStream.Position = br.BaseStream.Position + 1344

        Next
    End Sub

    Public Shared Function bitworking_Country_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 2147483648)
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1879048192)
        aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 267911168)
        aux1 = aux1 >> 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 523264)
        aux1 = aux1 << 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 768)
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 255)
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Derby_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12

        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)
            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = br.ReadUInt16
            Aux16 = bitworking_Derby_toConsole(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            br.BaseStream.Position = br.BaseStream.Position + 2


        Next
    End Sub

    Public Shared Function bitworking_Derby_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("110000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1110000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111111", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Derby_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12

        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1


            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)
            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = swaps.swap16(br.ReadUInt16)
            Aux16 = bitworking_Derby_toPc(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            br.BaseStream.Position = br.BaseStream.Position + 2


        Next
    End Sub

    Public Shared Function bitworking_Derby_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("110000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111111000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1110000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Coach_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 108
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1



            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Coach32_1_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Coach32_2_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = swaps.swap16(br.ReadUInt16)
            Aux16 = bitworking_Coach16_1_toPc(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)



            br.BaseStream.Position = br.BaseStream.Position + 94



        Next
    End Sub

    Public Shared Function bitworking_Coach16_1_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111110000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111110000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Coach32_1_toPc(ByVal value As UInt32) As UInt32


        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1", 2))
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110", 2))
        aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000", 2))
        aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111111000000000", 2))
        aux1 = aux1 << 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111110000000000000000", 2))
        aux1 = aux1 >> 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111100000000000000000000000", 2))
        aux1 = aux1 >> 23
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Coach32_2_toPc(ByVal value As UInt32) As UInt32


        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100", 2))
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado

    End Function



    Public Shared Sub Coach_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 108
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1



            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Coach32_1_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Coach32_2_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = br.ReadUInt16
            Aux16 = bitworking_Coach16_1_toConsole(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)



            br.BaseStream.Position = br.BaseStream.Position + 94



        Next
    End Sub

    Public Shared Function bitworking_Coach16_1_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111111000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111111", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Coach32_1_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000000", 2))
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000000", 2))
        aux1 = aux1 >> 28
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000000", 2))
        aux1 = aux1 >> 20
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111110000000000000000", 2))
        aux1 = aux1 >> 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111111000000000", 2))
        aux1 = aux1 << 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111111", 2))
        aux1 = aux1 << 23
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Coach32_2_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000000000000000000000", 2))
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function



    Public Shared Sub CompetitionRegulation_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 148
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0

        Dim Aux As Byte
        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            br.BaseStream.Position = br.BaseStream.Position + 1
            Aux = br.ReadByte
            br.BaseStream.Position = br.BaseStream.Position - 1
            Aux = rotr(Aux, 1)
            Grabar.Write(Aux)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_CompetitionRegulation32_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux16 = swaps.swap16(br.ReadUInt16)
            Aux16 = bitworking_CompetitionRegulation16_1_toPc(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)


            Aux = br.ReadByte
            br.BaseStream.Position = br.BaseStream.Position - 1
            Aux = Reverse_byte(Aux)
            Grabar.Write(Aux)


            Aux = br.ReadByte
            br.BaseStream.Position = br.BaseStream.Position - 1
            Aux = Reverse_byte(Aux)
            Grabar.Write(Aux)



            br.BaseStream.Position = br.BaseStream.Position + 132



        Next
    End Sub

    Public Shared Function bitworking_CompetitionRegulation16_1_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1", 2))
        aux1 = aux1 << 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("10", 2))
        aux1 = aux1 << 13
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1100", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1110000", 2))
        aux1 = aux1 << 5
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1110000000", 2))
        aux1 = aux1 >> 1
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1110000000000", 2))
        aux1 = aux1 >> 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1110000000000000", 2))
        aux1 = aux1 >> 13
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_CompetitionRegulation32_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0




        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111", 2))
        aux1 = aux1 << 29
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111000", 2))
        aux1 = aux1 << 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function


    Public Shared Sub CompetitionRegulation_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 148
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0

        Dim Aux As Byte
        Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            br.BaseStream.Position = br.BaseStream.Position + 1
            Aux = br.ReadByte
            br.BaseStream.Position = br.BaseStream.Position - 1
            Aux = rotl(Aux, 1)
            Grabar.Write(Aux)

            Aux32 = br.ReadUInt32
            Aux32 = bitworking_CompetitionRegulation32_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux16 = swaps.swap16(br.ReadUInt16)
            Aux16 = bitworking_CompetitionRegulation16_1_toConsole(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)


            Aux = br.ReadByte
            br.BaseStream.Position = br.BaseStream.Position - 1
            Aux = Reverse_byte(Aux)
            Grabar.Write(Aux)


            Aux = br.ReadByte
            br.BaseStream.Position = br.BaseStream.Position - 1
            Aux = Reverse_byte(Aux)
            Grabar.Write(Aux)



            br.BaseStream.Position = br.BaseStream.Position + 132


        Next
    End Sub

    Public Shared Function bitworking_CompetitionRegulation16_1_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1000000000000000", 2))
        aux1 = aux1 >> 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("100000000000000", 2))
        aux1 = aux1 >> 13
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111000000000", 2))
        aux1 = aux1 >> 5
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111000000", 2))
        aux1 = aux1 << 1
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111000", 2))
        aux1 = aux1 << 7
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111", 2))
        aux1 = aux1 << 13
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_CompetitionRegulation32_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0




        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11100000000000000000000000000000", 2))
        aux1 = aux1 >> 29
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111000000000000000000000000", 2))
        aux1 = aux1 >> 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function


    Public Shared Sub Player_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 192
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        ' Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Player32_1_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Player32_14_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Player32_2_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)



            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Player32_2_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Player32_2_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = bitworking_Player32_2_toPc(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = swaps.swap32(bitworking_Player32_12_toPc(Aux32))
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = swaps.swap32(bitworking_Player32_13_toPc(Aux32))
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            Aux32 = Reverse_int32(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Dim uno As Byte
            uno = br.ReadByte
            uno = Reverse_byte(uno)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(uno)


            br.BaseStream.Position = br.BaseStream.Position + 143


        Next
    End Sub

    Public Shared Function bitworking_Player32_1_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111000000", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111100000000000000", 2))
        aux1 = aux1 >> 5
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111100000000000000000000000", 2))
        aux1 = aux1 >> 23
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_6_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1", 2))
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110", 2))
        aux1 = aux1 << 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000000000", 2))
        'aux1 = aux1 << 11
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111110000000000000000000000000", 2))
        aux1 = aux1 >> 25
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_7_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1", 2))
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110", 2))
        aux1 = aux1 << 27
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000", 2))
        aux1 = aux1 << 21
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000", 2))
        aux1 = aux1 << 15
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000", 2))
        aux1 = aux1 << 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11110000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111100000000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111000000000000000000000", 2))
        aux1 = aux1 >> 15
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_8_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1", 2))
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110", 2))
        aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000", 2))
        aux1 = aux1 << 24
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000", 2))
        aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000", 2))
        aux1 = aux1 << 16
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000", 2))
        aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000", 2))
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000", 2))
        'aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000", 2))
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000", 2))
        aux1 = aux1 >> 8
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000", 2))
        aux1 = aux1 >> 16
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000", 2))
        aux1 = aux1 >> 20
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000", 2))
        aux1 = aux1 >> 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11100000000000000000000000000000", 2))
        aux1 = aux1 >> 29
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player16_1_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And 3)
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 508)
        aux1 = aux1 << 5
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 65024)
        aux1 = aux1 >> 9
        valuecambiado = (aux1 Or valuecambiado)




        'valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_2_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 3)
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 252)
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16128)
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1032192)
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 66060288)
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4227858432)
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_3_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 7)
        aux1 = aux1 << 29
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 248)
        aux1 = aux1 << 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16128)
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1032192)
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 66060288)
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4227858432)
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_4_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 1)
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 6)
        aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 24)
        aux1 = aux1 << 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 96)
        aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 384)
        aux1 = aux1 << 16
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1536)
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 6144)
        aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 24576)
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 98304)
        'aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 393216)
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 3670016)
        aux1 = aux1 >> 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 29360128)
        aux1 = aux1 >> 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 234881024)
        aux1 = aux1 >> 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4026531840)
        aux1 = aux1 >> 28
        valuecambiado = (aux1 Or valuecambiado)


        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_5_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        Dim Reversed As UInt32 = Reverse_int32(value)


        aux1 = value
        aux1 = (aux1 And 805306368)
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 3221225472)
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = Reversed
        aux1 = (aux1 And 4294967280)
        'aux1 = aux1 << 24
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_9_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        Dim Reversed As UInt32 = Reverse_int32(value)




        aux1 = Reversed
        aux1 = (aux1 And Convert.ToUInt32("11111111111111111111111100000000", 2))
        'aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000", 2))
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000", 2))
        aux1 = aux1 >> 18
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_10_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11110000000000000000000000000000", 2))
        aux1 = aux1 >> 28
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111000000000000000000000000", 2))
        aux1 = aux1 >> 20
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111000000000000000000000", 2))
        aux1 = aux1 >> 13
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111000000000000000000", 2))
        aux1 = aux1 >> 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111000000000000000", 2))
        aux1 = aux1 >> 1
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111000000000000", 2))
        aux1 = aux1 << 5
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000", 2))
        aux1 = aux1 << 18
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000", 2))
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)



        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_11_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000", 2))
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000", 2))
        aux1 = aux1 >> 18
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000", 2))
        aux1 = aux1 << 17
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1000000", 2))
        aux1 = aux1 << 19
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("100000", 2))
        aux1 = aux1 << 21
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000", 2))
        aux1 = aux1 << 23
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1000", 2))
        aux1 = aux1 << 25
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("100", 2))
        aux1 = aux1 << 27
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10", 2))
        aux1 = aux1 << 29
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1", 2))
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)


        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_12_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111000000000000000000000000000", 2))
        aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111100000000000000000000000", 2))
        aux1 = aux1 >> 18
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11110000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000", 2))
        aux1 = aux1 >> 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000", 2))
        aux1 = aux1 << 3
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000", 2))
        aux1 = aux1 << 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000", 2))
        aux1 = aux1 << 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000", 2))
        aux1 = aux1 << 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_13_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000", 2))
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000", 2))
        aux1 = aux1 >> 18
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)
        '''''

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000", 2))
        aux1 = aux1 << 18
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000", 2))
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10", 2))
        aux1 = aux1 << 29
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1", 2))
        aux1 = aux1 << 31
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_14_toPc(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111110000000000000000000000000", 2))
        aux1 = aux1 >> 25
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111111000000000000000000", 2))
        aux1 = aux1 >> 11
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)


        'valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function


    Public Shared Sub Player_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 192
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        ' Dim Aux16 As UInt16
        Dim Aux32 As UInt32


        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_1_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_14_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_2_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)



            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_2_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_2_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)
            '''''cambiado de 3 a 2 y parece funcionar
            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_2_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            'estoy con este
            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_12_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)


            Aux32 = br.ReadUInt32
            Aux32 = bitworking_Player32_13_toConsole(Aux32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux32 = br.ReadUInt32
            Aux32 = swaps.swap32(Reverse_int32(Aux32))
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Dim uno As Byte
            uno = br.ReadByte
            uno = Reverse_byte(uno)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(uno)


            br.BaseStream.Position = br.BaseStream.Position + 143


        Next
    End Sub

    Public Shared Function bitworking_Player32_1_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111111000000000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111111000000000", 2))
        aux1 = aux1 << 5
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111111", 2))
        aux1 = aux1 << 23
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado



    End Function

    Public Shared Function bitworking_Player16_1_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And 49152)
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16256)
        aux1 = aux1 >> 5
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 127)
        aux1 = aux1 << 9
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_2_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 3221225472)
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1056964608)
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16515072)
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 258048)
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4032)
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 63)
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_3_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 3758096384)
        aux1 = aux1 >> 29
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 520093696)
        aux1 = aux1 >> 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 16515072)
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 258048)
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 4032)
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 63)
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_4_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0

        aux1 = value
        aux1 = (aux1 And 2147483648)
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 1610612736)
        aux1 = aux1 >> 28
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 402653184)
        aux1 = aux1 >> 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 100663296)
        aux1 = aux1 >> 20
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 25165824)
        aux1 = aux1 >> 16
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 6291456)
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And 1572864)
        aux1 = aux1 >> 8
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 393216)
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 98304)
        'aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 24576)
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 7168)
        aux1 = aux1 << 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 896)
        aux1 = aux1 << 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 112)
        aux1 = aux1 << 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 15)
        aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_5_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        Dim Reversed As UInt32 = Reverse_int32(value)


        aux1 = value
        aux1 = (aux1 And 12)
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And 3)
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = Reversed
        aux1 = (aux1 And 268435455)
        'aux1 = aux1 << 24
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_6_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000000", 2))
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000000000000000000000", 2))
        aux1 = aux1 >> 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000000000", 2))
        'aux1 = aux1 << 11
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111110000000", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111111", 2))
        aux1 = aux1 << 25
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_7_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000000", 2))
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000000000000", 2))
        aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000000000", 2))
        aux1 = aux1 >> 21
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000000", 2))
        aux1 = aux1 >> 15
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000", 2))
        aux1 = aux1 >> 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111000000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111100000000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111000000", 2))
        aux1 = aux1 << 15
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111111", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)

        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_8_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000000", 2))
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000000", 2))
        aux1 = aux1 >> 28
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000", 2))
        aux1 = aux1 >> 24
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000", 2))
        aux1 = aux1 >> 20
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000", 2))
        aux1 = aux1 >> 16
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000", 2))
        aux1 = aux1 >> 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000", 2))
        aux1 = aux1 >> 8
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000", 2))
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000", 2))
        'aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000", 2))
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000", 2))
        aux1 = aux1 << 8
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000", 2))
        aux1 = aux1 << 12
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000", 2))
        aux1 = aux1 << 16
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000", 2))
        aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000", 2))
        aux1 = aux1 << 24
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111", 2))
        aux1 = aux1 << 29
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_9_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        Dim Reversed As UInt32 = Reverse_int32(value)




        aux1 = Reversed
        aux1 = (aux1 And Convert.ToUInt32("111111111111111111111111", 2))
        'aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000", 2))
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000", 2))
        aux1 = aux1 << 18
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_10_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111", 2))
        aux1 = aux1 << 28
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11110000", 2))
        aux1 = aux1 << 20
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11100000000", 2))
        aux1 = aux1 << 13
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11100000000000", 2))
        aux1 = aux1 << 7
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11100000000000000", 2))
        aux1 = aux1 << 1
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11100000000000000000", 2))
        aux1 = aux1 >> 5
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000", 2))
        aux1 = aux1 >> 18
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000", 2))
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)



        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_11_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000", 2))
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000", 2))
        aux1 = aux1 << 18
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)
        '''''
        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1000000000000000000000000", 2))
        aux1 = aux1 >> 17
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000", 2))
        aux1 = aux1 >> 19
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("100000000000000000000000000", 2))
        aux1 = aux1 >> 21
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1000000000000000000000000000", 2))
        aux1 = aux1 >> 23
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000", 2))
        aux1 = aux1 >> 25
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("100000000000000000000000000000", 2))
        aux1 = aux1 >> 27
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1000000000000000000000000000000", 2))
        aux1 = aux1 >> 29
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000000", 2))
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_12_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111", 2))
        aux1 = aux1 << 27
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("111100000", 2))
        aux1 = aux1 << 18
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000", 2))
        aux1 = aux1 << 3
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000", 2))
        aux1 = aux1 >> 3
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000", 2))
        aux1 = aux1 >> 9
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000000", 2))
        aux1 = aux1 >> 15
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1110000000000000000000000000", 2))
        aux1 = aux1 >> 21
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000000000", 2))
        aux1 = aux1 >> 30
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_13_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11", 2))
        aux1 = aux1 << 30
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100", 2))
        aux1 = aux1 << 26
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000", 2))
        aux1 = aux1 << 22
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000", 2))
        aux1 = aux1 << 18
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000", 2))
        aux1 = aux1 << 14
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000", 2))
        aux1 = aux1 << 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000", 2))
        aux1 = aux1 >> 10
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)
        '''''

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11000000000000000000000000", 2))
        aux1 = aux1 >> 18
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1100000000000000000000000000", 2))
        aux1 = aux1 >> 22
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("110000000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1000000000000000000000000000000", 2))
        aux1 = aux1 >> 29
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("10000000000000000000000000000000", 2))
        aux1 = aux1 >> 31
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Function bitworking_Player32_14_toConsole(ByVal value As UInt32) As UInt32

        Dim aux1 As UInt32 = 0
        Dim valuecambiado As UInt32 = 0
        'Dim Reversed As UInt32 = Reverse_int32(value)



        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("1111111", 2))
        aux1 = aux1 << 25
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111110000000", 2))
        aux1 = aux1 << 11
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000", 2))
        aux1 = aux1 >> 14
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt32("11111100000000000000000000000000", 2))
        aux1 = aux1 >> 26
        valuecambiado = (aux1 Or valuecambiado)


        valuecambiado = swaps.swap32(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Glove(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 204
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream

        Dim Position As UInt32 = 0
        br.BaseStream.Position = 0
        Dim i As UInt32 = 0
        Dim Aux As UInt16
        For i = 0 To num_of_blocks - 1
            Aux = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux)
            br.BaseStream.Position = br.BaseStream.Position + 202
        Next
    End Sub

    Public Shared Sub Tactics_toPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32
        Dim Aux As Byte

        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux16 = swaps.swap16(br.ReadUInt16)
            Aux16 = bitworking_Tactics_16_1_toPc(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux = br.ReadByte
            Aux = Reverse_byte(Aux)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)


            br.BaseStream.Position = br.BaseStream.Position + 3





        Next
    End Sub

    Public Shared Function bitworking_Tactics_16_1_toPc(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        'value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1100", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11110000", 2))
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111100000000", 2))
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111000000000000", 2))
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Tactics_toConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32
        Dim Aux As Byte

        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux16 = br.ReadUInt16
            Aux16 = bitworking_Tactics_16_1_toConsole(Aux16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)

            Aux = br.ReadByte
            Aux = Reverse_byte(Aux)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)


            br.BaseStream.Position = br.BaseStream.Position + 3





        Next
    End Sub

    Public Shared Function bitworking_Tactics_16_1_toConsole(ByVal value As UInt16) As UInt16

        Dim aux1 As UInt16 = 0
        Dim valuecambiado As UInt16 = 0
        value = swaps.swap16(value)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111", 2))
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("110000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("111100000000", 2))
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111000000000000", 2))
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)




        valuecambiado = swaps.swap16(valuecambiado)
        Return valuecambiado


    End Function

    Public Shared Sub Tactics_FormationToConsole(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32
        Dim Aux As Byte

        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)


            br.BaseStream.Position = br.BaseStream.Position + 2


            Aux = br.ReadByte
            Aux = bitworking_TacticsFormation_toConsole(Aux)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)


            br.BaseStream.Position = br.BaseStream.Position + 3





        Next
    End Sub

    Public Shared Function bitworking_TacticsFormation_toConsole(ByVal value As Byte) As Byte

        Dim aux1 As Byte = 0
        Dim valuecambiado As Byte = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1111", 2))
        aux1 = aux1 << 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("110000", 2))
        aux1 = aux1 >> 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11000000", 2))
        aux1 = aux1 >> 6
        valuecambiado = (aux1 Or valuecambiado)

        Return valuecambiado


    End Function




    Public Shared Sub Tactics_FormationToPc(ByRef stream As MemoryStream)
        Dim num_of_blocks As Integer = stream.Length / 12
        Dim br As New BinaryReader(stream)
        Dim Grabar As New BinaryWriter(stream)
        Dim stream_value As New MemoryStream


        br.BaseStream.Position = 0
        Dim i As UInt32 = 0


        Dim Aux16 As UInt16
        Dim Aux32 As UInt32
        Dim Aux As Byte

        For i = 0 To num_of_blocks - 1

            Aux32 = swaps.swap32(br.ReadUInt32)
            br.BaseStream.Position = br.BaseStream.Position - 4
            Grabar.Write(Aux32)

            Aux16 = swaps.swap16(br.ReadUInt16)
            br.BaseStream.Position = br.BaseStream.Position - 2
            Grabar.Write(Aux16)


            br.BaseStream.Position = br.BaseStream.Position + 2


            Aux = br.ReadByte
            Aux = bitworking_TacticsFormation_toPc(Aux)
            br.BaseStream.Position = br.BaseStream.Position - 1
            Grabar.Write(Aux)


            br.BaseStream.Position = br.BaseStream.Position + 3





        Next
    End Sub

    Public Shared Function bitworking_TacticsFormation_toPc(ByVal value As Byte) As Byte

        Dim aux1 As Byte = 0
        Dim valuecambiado As Byte = 0


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11110000", 2))
        aux1 = aux1 >> 4
        valuecambiado = (aux1 Or valuecambiado)

        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("1100", 2))
        aux1 = aux1 << 2
        valuecambiado = (aux1 Or valuecambiado)


        aux1 = value
        aux1 = (aux1 And Convert.ToUInt16("11", 2))
        aux1 = aux1 << 6
        valuecambiado = (aux1 Or valuecambiado)

        Return valuecambiado


    End Function

End Class
