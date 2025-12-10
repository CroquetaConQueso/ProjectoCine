using System;

namespace AplicacionCine.Modelos
{
    /// <summary>
    /// Información lógica de una butaca en el mapa:
    /// posición (fila/columna), estado y tipo de asiento.
    /// Se usa en FrmMapaButacas para pintar y guardar.
    /// </summary>
    public class InfoButaca
    {

        public int Fila { get; set; }


        public int Columna { get; set; }


        public EstadoButaca Estado { get; set; }

        public TipoAsiento Tipo { get; set; }
    }
}
