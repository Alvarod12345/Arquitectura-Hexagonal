namespace CrossCutting.Utility.OxiServi.Constants
{
    public class ApplicationConstants
    {
        public class TimeZone
        {
            public const string Peru = "SA Pacific Standard Time";
        }
        public class NotificationMessageType
        {
            public const string FORMFIELDS = "1";
            public const string BUSINESSLOGIC = "2";
            public const string INTERNALERROR = "3";
            public const string BD_ERROR = "4";
        }
        public enum TipoDocumentoEnum
        {
            DNI = 1,
            CARNET_DE_EXTRANJERIA = 2,
            REG_UNICO_DE_CONTRIBUYENTES = 3,
            PASAPORTE = 4,
            PARTIDA_NACIMIENTO = 5
        }
        public enum TipoComprobante
        {
            FACTURA = 1,
            BOLETA = 2
        }
        public enum DigitosDocumentoEnum
        {
            DNI = 8,
            CARNET_DE_EXTRANJERIA = 12,
            REG_UNICO_DE_CONTRIBUYENTES = 11,
            PASAPORTE = 12,
            PARTIDA_NACIMIENTO = 15
        }
    }
    public class TemplateConstans
    {
        public static string facturaTemplate = "<tr>" +
                                            "<td style=\"font-weight:bold;font-size:9.5px;border:1.7px solid darkgreen;border-collapse: collapse; width:80px; max-width:100px !important;border-style: dotted;\">" +
                                                "{Serie}" +
                                            "</td>"+
                                            "<td style = \"font-weight:bold;font-size:9.5px;border:1.7px solid darkgreen;border-collapse: collapse; width:80px; max-width:100px !important;border-style: dotted;\">"+
                                                "{Descripcion}"+
                                            "</td>"+
                                            "<td style=\"font-weight:bold;font-size:9.5px;border:1.7px solid darkgreen;border-collapse: collapse; width:80px; max-width:100px !important;border-style: dotted;\">"+
                                               "{PUnitario}"+
                                            "</td>"+
                                        "</tr>";
        public static string cotizacionTemplate = "<tr>" +
                                            "<td style=\"font-weight:bold;font-size:9.5px;border:1.7px solid darkgreen;border-collapse: collapse; width:80px; max-width:100px !important;border-style: dotted;\">" +
                                                "{Serie}" +
                                            "</td>" +
                                            "<td style = \"font-weight:bold;font-size:9.5px;border:1.7px solid darkgreen;border-collapse: collapse; width:80px; max-width:100px !important;border-style: dotted;\">" +
                                                "{Descripcion}" + " " + "({Capacidad})"+
                                            "<td style=\"font-weight:bold;font-size:9.5px;border:1.7px solid darkgreen;border-collapse: collapse; width:80px; max-width:100px !important;border-style: dotted;\">" +
                                               "{PUnitario}" +
                                            "</td>" +
                                        "</tr>";
    }
}
