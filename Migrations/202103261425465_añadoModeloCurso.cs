namespace Miel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class añadoModeloCurso : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cursoes", newName: "CursoModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CursoModels", newName: "Cursoes");
        }
    }
}
