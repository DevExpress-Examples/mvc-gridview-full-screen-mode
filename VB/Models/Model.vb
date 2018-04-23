Imports System
Imports System.Data
Imports System.Collections.Generic

Public Class InMemoryModel
    Private Const DataItemsCount As Integer = 100

    Private privateID As Integer
    Public Property ID() As Integer
        Get
            Return privateID
        End Get
        Set(ByVal value As Integer)
            privateID = value
        End Set
    End Property
    Private privateText As String
    Public Property Text() As String
        Get
            Return privateText
        End Get
        Set(ByVal value As String)
            privateText = value
        End Set
    End Property
    Private privateQuantity As Integer
    Public Property Quantity() As Integer
        Get
            Return privateQuantity
        End Get
        Set(ByVal value As Integer)
            privateQuantity = value
        End Set
    End Property
    Private privatePrice As Decimal
    Public Property Price() As Decimal
        Get
            Return privatePrice
        End Get
        Set(ByVal value As Decimal)
            privatePrice = value
        End Set
    End Property

    Public Shared Function GetTypedListModel() As List(Of InMemoryModel)
        Dim typedList As List(Of InMemoryModel) = New List(Of InMemoryModel)()

        Dim randomizer As New Random()

        For index As Integer = 0 To DataItemsCount - 1
            typedList.Add(New InMemoryModel() With {.ID = index, .Text = "Text" & index.ToString(), .Quantity = randomizer.Next(1, 50), .Price = CDec(Math.Round((randomizer.NextDouble() * 100), 2))})
        Next index

        Return typedList
    End Function
End Class