Public Class Form1

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim producto1, producto2, producto3 As String
        Dim precio1, precio2, precio3 As Double
        producto1 = TextBox1Producto1.Text
        producto2 = TextBox1Producto2.Text
        producto3 = TextBox2Producto3.Text
        precio1 = TextBox1PrecioProducto1.Text
        precio2 = TextBox2PrecioProducto2.Text
        precio3 = TextBox1PrecioProducto3.Text
        TextBoxSubtotal.Text = Math.Round(subtotal(precio1, precio2, precio3), 2)
        TextBoxIVA.Text = Math.Round(IVA(precio1, precio2, precio3), 2)
        TextBoxDescuento.Text = Math.Round(descuento(precio1, precio2, precio3), 2)
        TextBoxtotal.Text = Math.Round(total(precio1, precio2, precio3), 2)
        mostrar(producto1, producto2, producto3, precio1, precio2, precio3)


    End Sub
    'CALCULAR SUBTOTAL
    Function subtotal(precio1, precio2, precio3) As Double
        Return precio1 + precio2 + precio3
    End Function
    'CALCULAR IVA
    Function IVA(precio1, precio2, precio3) As Double
        Return subtotal(precio1, precio2, precio3) * 0.13
    End Function
    'CALCULAR DESCUENTO
    Function descuento(precio1, precio2, precio3) As Double
        If subtotal(precio1, precio2, precio3) < 0 Then
            Return MsgBox("Dato incorrecto")
        Else
            If subtotal(precio1, precio2, precio3) > 0 And subtotal(precio1, precio2, precio3) < 25 Then
                Return 0
            Else
                If subtotal(precio1, precio2, precio3) > 25 And subtotal(precio1, precio2, precio3) < 100 Then
                    Return subtotal(precio1, precio2, precio3) * 0.05
                Else
                    If subtotal(precio1, precio2, precio3) > 100 And subtotal(precio1, precio2, precio3) < 150 Then
                        Return subtotal(precio1, precio2, precio3) * 0.1
                    Else
                        Return subtotal(precio1, precio2, precio3) * 0.15

                    End If
                End If
            End If
        End If
    End Function
    'CALCULAR TOTAL
    Function total(precio1, precio2, precio3) As Double
        Return (subtotal(precio1, precio2, precio3) - descuento(precio1, precio2, precio3)) + IVA(precio1, precio2, precio3)
    End Function

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub TextBox1PrecioProducto1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1PrecioProducto1.TextChanged
        If TextBox1PrecioProducto1.Text < 0 Then
            MsgBox("Dato incorrecto")
            TextBox1PrecioProducto1.Focus()
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub TextBox1PrecioProducto3_TextChanged(sender As Object, e As EventArgs) Handles TextBox1PrecioProducto3.TextChanged
        If TextBox1PrecioProducto1.Text < 0 Then
            MsgBox("Dato incorrecto")
            TextBox1PrecioProducto1.Focus()
        Else
            Button1.Enabled = True
        End If
    End Sub

    Sub mostrar(producto1 As String, producto2 As String, producto3 As String, precio1 As Double, precio2 As Double, precio3 As Double)
        Label11P1.Visible = True
        Label12P2.Visible = True
        Label13P3.Visible = True
        Label11pr1.Visible = True
        Label12pr2.Visible = True
        Label13pr3.Visible = True
        Label11P1.Text = producto1
        Label12P2.Text = producto2
        Label13P3.Text = producto3
        Label11pr1.Text = "$" & precio1
        Label12pr2.Text = "$" & precio2
        Label13pr3.Text = "$" & precio3

    End Sub

    Private Sub TextBox1Producto1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1Producto1.TextChanged
        If TextBox1Producto1.Text = "" Then
            MsgBox("Ingresa un dato")
            TextBox1Producto1.Focus()
        Else
            Button1.Enabled = False
        End If
    End Sub

End Class
