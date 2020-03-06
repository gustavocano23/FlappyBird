Public Class Form1
    Dim yspeed As Integer = 0
    Dim gravedad As Integer = 4
    Dim pipes(1) As PictureBox
    Dim toppipes(1) As PictureBox
    Dim pipespeed As Single = 9
    Dim cont As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        Timer1.Enabled = True
        CreatePipes(1)
        CreateTopPipes(1)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        yspeed += gravedad
        PictureBox1.Top += yspeed
        For i = 0 To 1
            pipes(i).Left -= pipespeed
            toppipes(i).Left -= pipespeed
            If Collision(pipes(i), PictureBox1) = True Or Collision(toppipes(i), PictureBox1) = True Then
                Application.Exit()
            End If
            If (PictureBox1.Location.Y >= 284) Or (PictureBox1.Location.Y <= 0) Then
                Application.Exit()
            End If

            If pipes(i).Left < 0 Then
                pipes(i).Left += 400
                toppipes(i).Left += 400
                pipes(i).Top = 70 + 290 * Rnd()
                toppipes(i).Top = pipes(i).Top - 460
                cont = cont + 1
                Label2.Text = cont
                If cont Mod 5 = 0 Then
                    Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\sprites\background-night.png")
                    Me.BackgroundImageLayout = ImageLayout.Stretch
                End If
                If cont Mod 10 = 0 Then
                    Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\sprites\background-day.png")
                    Me.BackgroundImageLayout = ImageLayout.Stretch
                End If

                'If cont <= 9 Then
                '    PictureBox3.BackgroundImage = Image.FromFile("C:\Users\gusta\Desktop\Flappy_bird2\Flappy_bird2\sprites\" & cont & ".png")
                '    PictureBox3.BackgroundImageLayout = ImageLayout.Center
                'End If
                'If cont > 9 Or cont >= 19 Then
                '    PictureBox4.Visible = True
                '    PictureBox3.BackgroundImage = Image.FromFile("C:\Users\gusta\Desktop\Flappy_bird2\Flappy_bird2\sprites\1.png")
                '    PictureBox3.BackgroundImageLayout = ImageLayout.Center
                '    PictureBox4.BackgroundImage = Image.FromFile("C:\Users\gusta\Desktop\Flappy_bird2\Flappy_bird2\sprites\" & cont - 10 & ".png")
                '    PictureBox4.BackgroundImageLayout = ImageLayout.Center
                'End If

            End If
        Next
    End Sub

    Private Sub CreatePipes(ByVal number As Integer)
        Dim i As Integer = 0
        For i = 0 To number
            Dim temp As New PictureBox
            Me.Controls.Add(temp)
            temp.Width = 50
            temp.Height = 350
            temp.BackgroundImage = Image.FromFile(Application.StartupPath & "\sprites\pipe-green.png")
            temp.BackgroundImageLayout = ImageLayout.Stretch
            temp.BackColor = Color.Transparent
            temp.Top = 70 + 290 * Rnd()
            temp.Left = (i * 200) + 300
            pipes(i) = temp
            pipes(i).Visible = True
        Next
    End Sub

    Private Sub CreateTopPipes(ByVal number As Integer)
        Dim i As Integer = 0
        For i = 0 To number
            Dim temp As New PictureBox
            Me.Controls.Add(temp)
            temp.Width = 50
            temp.Height = 350
            temp.BackgroundImage = Image.FromFile(Application.StartupPath & "\sprites\pipe-green1.png")
            temp.BackgroundImageLayout = ImageLayout.Stretch
            temp.BackColor = Color.Transparent
            temp.Top = pipes(i).Top - 460
            temp.Left = (i * 200) + 300
            toppipes(i) = temp
            toppipes(i).Visible = True
        Next
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Space) Then
            yspeed += -22
        End If
    End Sub

    Public Function Collision(ByVal Object1 As Object, ByVal Object2 As Object) As Boolean
        Dim collided As Boolean = False
        If Object1.Top + Object1.Height >= Object2.Top And
           Object2.Top + Object2.Height >= Object1.Top And
           Object1.Left + Object1.Width >= Object2.left And
           Object2.Left + Object2.Width >= Object1.left And Object1.visible = True And Object2.visible = True Then
            collided = True
        End If
        Return collided
    End Function
End Class
