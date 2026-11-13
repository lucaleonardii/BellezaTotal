using BellezaTotal_BLL;
using BellezaTotal_BLL.Clases;
using BellezaTotal_UI;
using System;
using System.Windows.Forms;

public static class TraductorDeControles
{
    public static void Traducir(Form formulario)
    {
        string prefijo = formulario.Name;

        AplicarSiExiste(prefijo + ".Text", textoTraducido => formulario.Text = textoTraducido);
        TraducirControles(prefijo, formulario.Controls);
    }

    private static void TraducirControles(string prefijo, Control.ControlCollection controles)
    {
        foreach (Control control in controles)
        {
            if (control is UC_BotonMenu botonMenu)
            {
                AplicarSiExiste(
                    prefijo + "." + control.Name,
                    textoTraducido => botonMenu.TituloMenu = textoTraducido
                );
            }
            else if (control is Label ||
                     control is ButtonBase ||
                     control is GroupBox ||
                     control is TabPage)
            {
                AplicarSiExiste(
                    prefijo + "." + control.Name,
                    textoTraducido => control.Text = textoTraducido
                );
            }

            if (control is DataGridView grilla)
                TraducirColumnas(prefijo, grilla);

            if (control is ToolStrip barraDeHerramientas)
                TraducirItems(prefijo, barraDeHerramientas.Items);

            TraducirControles(prefijo, control.Controls);


        }


    }
    public static string ObtenerTexto(string clave, string textoOriginal)
    {
        if (IdiomaManager.Instancia.TryObtenerLeyenda(
            clave, out string textoTraducido))
        {
            return textoTraducido;
        }

        return textoOriginal;
    }
    private static void TraducirColumnas(string prefijo, DataGridView grilla)
    {
        foreach (DataGridViewColumn columna in grilla.Columns)
        {
            AplicarSiExiste(
                prefijo + "." + grilla.Name + "." + columna.Name,
                textoTraducido => columna.HeaderText = textoTraducido);
        }
    }

    private static void TraducirItems(string prefijo, ToolStripItemCollection items)
    {
        foreach (ToolStripItem item in items)
        {
            bool esContenidoDelUsuario = item is ToolStripComboBox || item is ToolStripTextBox;

            if (!esContenidoDelUsuario)
                AplicarSiExiste(prefijo + "." + item.Name, textoTraducido => item.Text = textoTraducido);

            if (item is ToolStripDropDownItem itemDesplegable)
                TraducirItems(prefijo, itemDesplegable.DropDownItems);
        }
    }

    private static void AplicarSiExiste(string clave, Action<string> asignarTexto)
    {
        if (IdiomaManager.Instancia.TryObtenerLeyenda(clave, out string textoTraducido))
            asignarTexto(textoTraducido);
    }
}