namespace rr_protrack_back.Utils
{
    public static class DiaSemanaHelper
    {
        public static string TraduzirDiaSemana(string diaPtBr)
        {
            return diaPtBr.ToLowerInvariant() switch
            {
                "domingo" => "sunday",
                "segunda" => "monday",
                "terca" => "tuesday",
                "terça" => "tuesday",
                "quarta" => "wednesday",
                "quinta" => "thursday",
                "sexta" => "friday",
                "sabado" => "saturday",
                "sábado" => "saturday",
                _ => string.Empty
            };
        }
    }
}