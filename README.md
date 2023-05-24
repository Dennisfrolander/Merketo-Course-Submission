<h1 align="center"> Merketo kopia | ASP.NET Inlämning </h1>
<h4 align="center">Av Dennis Frölander</h4>


## Kort info:

Identity-databasen är tom, vilket innebär att användaren behöver skapa en ny användare första gången de besöker webbplatsen. Vid skapandet av denna användare tilldelas de automatiskt rollen som admin. Alla andra användare som registrerar sig blir standardanvändare, men administratören har möjlighet att ändra användarnas roller från admin backoffice om de vill ge dem en annan roll. Produkterna visas upp på första sidan med hjälp av 3 taggar (New, Featured och Popular). Showcasen slumpar fram en Featured produkt varje gång sidan uppdateras. Best Collection använder sig av taggen new, uptosale av 2 av de högsta rabatterna som finns på produkten och karusellen använder sig av popular taggen.


## Hur man startar programmet:
***Ändra connectionstrings i appsettings.json*** 

```"ConnectionStrings": {
    "Identity": "Identity-connectionstring",
    "Data": "mainDb-connection string"
  }
  ```
  
  ***Se till att du lagt till en connection mellan sqlserver och din lokaladatabas som finns i Models > Contexts > Databases (IdentityDatabase / MainDb).***
