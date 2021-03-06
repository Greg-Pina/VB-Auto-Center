' **************************************************************************************
' <Greg Pina>
' VB Auto Program Re-do
'.Net Programming IT 101-401
' <10/23/2017>
' This is homework 10 - Resubmit
' **************************************************************************************

Option Strict On

Public Class Form1


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'close the program
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'clear all the labels and textboxes and set trade in back to default value of 0
        txtBase.Clear()
        txtTrade.Clear()
        lblAF.ResetText()
        lblAmtDue.ResetText()
        lblSubtotal.Text = ""
        lblTax.Text = String.Empty

        chkLeather.Checked = False
        chkNav.Checked = False
        chkStereo.Checked = False

        radStandard.Checked = True



    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click

        ' constants for options and tax rate
        Const dblStereoPrice As Double = 500
        Const dblLeatherPrice As Double = 1000
        Const dblNavigationPrice As Double = 1500
        Const dblPearlPrice As Double = 500
        Const dblCustomPrice As Double = 750
        Const cdblTaxRate As Double = 0.6

        Dim dblAccFinish As Double
        Dim dblSubTotal As Double
        Dim dblTax As Double
        Dim dblAmountDue As Double
        Dim dblBasePrice As Double
        Dim dblTrade As Double

        'Get input and validate it
        Try
            If IsNumeric(txtBase.Text) Then
                dblBasePrice = CDbl(txtBase.Text)

            Else
                MessageBox.Show("Base Price Must Be Numeric", "Base Price Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBase.Focus()
                Exit Sub
            End If
            ' make sure base price is greater than 0
            If dblBasePrice <= 0 Then
                MessageBox.Show("Base Price Must Be Greater Than 0", "Base Price Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBase.Focus()
                Exit Sub
            End If

            If IsNumeric(Me.txtTrade.Text) Then
                dblTrade = CDbl(txtTrade.Text)

            Else
                MessageBox.Show("Trade In Must Be Numeric", "Trade In Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTrade.Focus()
                Exit Sub
            End If

            If dblTrade < 0 Then
                MessageBox.Show("Trade In Must Be 0 or More", "Trade In Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTrade.Focus()
                Exit Sub
            End If

            ' check out accessories 
            If chkLeather.Checked Then
                dblAccFinish += dblLeatherPrice
            End If

            If chkNav.Checked Then
                dblAccFinish += dblNavigationPrice
            End If

            If chkStereo.Checked Then
                dblAccFinish += dblStereoPrice
            End If

            If radPearl.Checked Then
                dblAccFinish += dblPearlPrice
            Else
                If radCustom.Checked Then
                    dblAccFinish += dblCustomPrice
                End If
            End If

            ' do our calculations
            dblSubTotal = (dblBasePrice + dblAccFinish) - (dblTrade)

            dblTax = (dblSubTotal) * (cdblTaxRate)

            dblAmountDue = dblSubTotal + dblTax

            ' display our outputs in currency
            lblAF.Text = dblAccFinish.ToString("c")

            lblTax.Text = dblTax.ToString("c")

            lblSubtotal.Text = dblSubTotal.ToString("c")

            lblAmtDue.Text = dblAmountDue.ToString("c")

            txtBase.Text = FormatCurrency(txtBase.Text)

            txtTrade.Text = FormatCurrency(txtTrade.Text)




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub
End Class
