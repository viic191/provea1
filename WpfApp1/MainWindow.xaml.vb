
Imports System.Windows.Controls
Imports LiveCharts
Imports LiveCharts.Wpf

''' <summary>
''' Interaction logic for StackedColumnExample.xaml
''' </summary>
Public Class MainWindow
    Public Sub New()
        InitializeComponent()

        ' this is not necessary, values is the default stack mode
        SeriesCollection = New SeriesCollection() From {
                New StackedColumnSeries() With {
                    .Values = New ChartValues(Of Double)() From {
                        4,
                        5,
                        6,
                        8
                    },
                    .StackMode = StackMode.Values,
                    .DataLabels = True
                },
                New StackedColumnSeries() With {
                    .Values = New ChartValues(Of Double)() From {
                        2,
                        5,
                        6,
                        7
                    },
                    .StackMode = StackMode.Values,
                    .DataLabels = True
                }
            }

        'adding series updates and animates the chart
        SeriesCollection.Add(New StackedColumnSeries() With {
                .Values = New ChartValues(Of Double)() From {
                    6,
                    2,
                    7
                },
                .StackMode = StackMode.Values
            })

        'adding values also updates and animates
        SeriesCollection(2).Values.Add(4.0)
        MessageBox.Show(SeriesCollection(2).ActualValues.ToString)

        Labels = {"Chrome", "Mozilla", "Opera", "IE"}
        Formatter = Function(value) String.Format(" {0} Mill", value.ToString)

        DataContext = Me
    End Sub

    Public Property SeriesCollection() As SeriesCollection
        Get
            Return m_SeriesCollection
        End Get
        Set
            m_SeriesCollection = Value
        End Set
    End Property
    Private m_SeriesCollection As SeriesCollection
    Public Property Labels() As String()
        Get
            Return m_Labels
        End Get
        Set
            m_Labels = Value
        End Set
    End Property
    Private m_Labels As String()
    Public Property Formatter() As Func(Of Double, String)
        Get
            Return m_Formatter
        End Get
        Set
            m_Formatter = Value
        End Set
    End Property
    Private m_Formatter As Func(Of Double, String)

End Class
