Imports System.Speech

Public Class Form1

    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine

    Private Sub SetColor(ByVal color As System.Drawing.Color)

        Dim synth As New Synthesis.SpeechSynthesizer

        synth.SpeakAsync("setting the back color to " + color.ToString)

        Me.BackColor = color

    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        reco.SetInputToDefaultAudioDevice()

        Dim gram As New Recognition.SrgsGrammar.SrgsDocument

        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("color")

        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("facebook", "youtube", "google")

        colorRule.Add(colorsList)

        gram.Rules.Add(colorRule)

        gram.Root = colorRule

        reco.LoadGrammar(New Recognition.Grammar(gram))

        reco.RecognizeAsync()

    End Sub

    Private Sub reco_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted

        reco.RecognizeAsync()

    End Sub

    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized

        Select Case e.Result.Text

            Case "facebook"

                Dim url As String = "https://www.facebook.com"
                Process.Start(url)

            Case "youtube"

                Dim url As String = "https://www.youtube.com/"
                Process.Start(url)

            Case "google"

                Dim url As String = "https://www.google.com/"
                Process.Start(url)

        End Select

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacebookToolStripMenuItem.Click

        Dim url As String = "https://www.facebook.com/sadik.fattah.7"
        Process.Start(url)
    End Sub

    Private Sub PlusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlusToolStripMenuItem.Click
        Dim url As String = "https://plus.google.com/110268382009035036954"
        Process.Start(url)
    End Sub

    Private Sub YoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubeToolStripMenuItem.Click
        Dim url As String = "https://www.youtube.com/channel/UCZr2VGmXdJ-yGLUZztCVFGw"
        Process.Start(url)
    End Sub
End Class