namespace mvc_gog.Models
{
    public class LigneBackup
    {

        public int LigneBackupID { get; set; }
        public int LignePanierID { get; set; }
        public int PanierID { get; set; }
        public int ProduitID { get; set; }
        public int NbreArticle { get; set; }
        public double Total { get; set; }
        public string? Prodname { get; set; }


        public LigneBackup(int ligneBackupID, int panierID, int produitID, int nbreArticle, double total, string prodname)
        {
            LignePanierID = ligneBackupID;
            PanierID = panierID;
            ProduitID = produitID;
            NbreArticle = nbreArticle;
            Total = total;
            this.Prodname = prodname;
        }
    }
}
