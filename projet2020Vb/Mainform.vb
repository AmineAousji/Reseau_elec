Public Class Mainform

    Private Shared IdCounter As Integer = 0
    Private ReadOnly MyNetwork As New Network
    Private ReadOnly MyWeather As New Weather
    Private ReadOnly MyMarket As New Market


    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        AddConsoleLine("Configurez le réseau pour commencer la simulation ...")

    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Public Sub AddConsoleLine(txt As String)
        RichTextBox1.Text = RichTextBox1.Text & "[" & Now.ToString & "] " & txt & Environment.NewLine
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        IdCounter += 1
        ComboBox3.Items.Add("Noeud de distribution - Id : " & IdCounter)
        ComboBox4.Items.Add("Noeud de distribution - Id : " & IdCounter)
        ListBox4.Items.Add("Noeud de distribution - Id : " & IdCounter)

        Dim myEntity As Entity = New Distribution(IdCounter)
        MyNetwork.AddEntityNetwork(myEntity)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        IdCounter += 1
        ComboBox3.Items.Add("Noeud de concentration - Id : " & IdCounter)
        ComboBox4.Items.Add("Noeud de concentration - Id : " & IdCounter)
        ListBox3.Items.Add("Noeud de concentration - Id : " & IdCounter)

        Dim myEntity As Entity = New Concentration(IdCounter)
        MyNetwork.AddEntityNetwork(myEntity)
    End Sub




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ComboBox3.Items.Remove(ListBox1.Items(ListBox1.SelectedIndex).ToString)
            MyNetwork.RemoveLineNetwork(ReturnIdEntityByString(ListBox1.SelectedItem.ToString))
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            ComboBox4.Items.Remove(ListBox4.Items(ListBox4.SelectedIndex).ToString)
            ComboBox3.Items.Remove(ListBox4.Items(ListBox4.SelectedIndex).ToString)
            MyNetwork.RemoveLineNetwork(ReturnIdEntityByString(ListBox4.SelectedItem.ToString))
            ListBox4.Items.RemoveAt(ListBox4.SelectedIndex)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            ComboBox4.Items.Remove(ListBox3.Items(ListBox3.SelectedIndex).ToString)
            ComboBox3.Items.Remove(ListBox3.Items(ListBox3.SelectedIndex).ToString)
            MyNetwork.RemoveLineNetwork(ReturnIdEntityByString(ListBox3.SelectedItem.ToString))
            ListBox3.Items.RemoveAt(ListBox3.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            ComboBox4.Items.Remove(ListBox2.Items(ListBox2.SelectedIndex).ToString)
            MyNetwork.RemoveLineNetwork(ReturnIdEntityByString(ListBox2.SelectedItem.ToString))
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ListBox1.Items.Add(ComboBox2.SelectedItem.ToString & " - Nom : " & TextBox1.Text & " - Id : " & IdCounter)
            ComboBox3.Items.Add(ComboBox2.SelectedItem.ToString & " - Nom : " & TextBox1.Text & " - Id : " & IdCounter)
            Dim myEntity As Entity
            If ComboBox2.SelectedIndex = 0 Then
                myEntity = New CentralGas(TextBox1.Text, IdCounter)
            ElseIf ComboBox2.SelectedIndex = 1 Then
                myEntity = New CentralNuclear(TextBox1.Text, IdCounter)
            ElseIf ComboBox2.SelectedIndex = 2 Then
                myEntity = New CentralSolar(TextBox1.Text, IdCounter, MyWeather)
            ElseIf ComboBox2.SelectedIndex = 3 Then
                myEntity = New PurchaseElectricity(TextBox1.Text, IdCounter, MyMarket)
            ElseIf ComboBox2.SelectedIndex = 4 Then
                myEntity = New WindFarm(TextBox1.Text, IdCounter, MyWeather)
            End If
            MyNetwork.AddEntityNetwork(myEntity)
            IdCounter += 1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ListBox2.Items.Add(ComboBox1.SelectedItem.ToString & " - Nom : " & TextBox2.Text & " - Id : " & IdCounter)
            ComboBox4.Items.Add(ComboBox1.SelectedItem.ToString & " - Nom : " & TextBox2.Text & " - Id : " & IdCounter)
            Dim myEntity As Entity
            If ComboBox1.SelectedIndex = 0 Then
                myEntity = New City(TextBox2.Text, IdCounter)
            ElseIf ComboBox1.SelectedIndex = 1 Then
                myEntity = New Company(TextBox2.Text, IdCounter)
            ElseIf ComboBox1.SelectedIndex = 2 Then
                myEntity = New HeatSink(TextBox2.Text, IdCounter)
            ElseIf ComboBox1.SelectedIndex = 3 Then
                myEntity = New PurchaseElectricity(TextBox2.Text, IdCounter, MyMarket)
            End If
            MyNetwork.AddEntityNetwork(myEntity)
            IdCounter += 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            MyNetwork.RemoveLineNetwork(ReturnIdLineByString(ListBox5.SelectedItem.ToString))
            ListBox5.Items.RemoveAt(ListBox5.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ComboBox3.SelectedIndex <> -1 And ComboBox4.SelectedIndex <> -1 Then
            IdCounter += 1
            MyNetwork.AddLineNetwork(IdCounter, ReturnIdEntityByString(ComboBox3.SelectedItem), ReturnIdEntityByString(ComboBox4.SelectedItem), NumericUpDown1.Value)
            ListBox5.Items.Add(ComboBox3.SelectedItem.ToString & " fournit de l'énergie à " & ComboBox4.SelectedItem.ToString & " - IdLine : " & IdCounter)
        End If

    End Sub

    Private Function ReturnIdEntityByString(myText As String)
        Return Split(myText, "Id : ")(1)
    End Function
    Private Function ReturnIdLineByString(myText As String)
        Return Split(myText, "IdLine : ")(1)
    End Function

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        MyWeather.EditSunshineLevel(NumericUpDown2.Value)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        MyMarket.EditBuyingPrice(TextBox3.Text)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        MyMarket.EditSellingPrice(TextBox5.Text)
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        MyWeather.EditWindForce(NumericUpDown3.Value)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            MyWeather.EditTemperature(TextBox4.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MyNetwork.UpdateEnergy()
        'AddConsoleLine(MyNetwork.GetLineMessage())
        AddConsoleLine(MyNetwork.GetGeneralMessage())
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Timer1.Enabled = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        RichTextBox1.Text = ""
    End Sub
End Class
