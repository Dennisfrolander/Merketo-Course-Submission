<h1 align="center"> Merketo kopia | ASP.NET Inlämning </h1>
<h4 align="center">Av Dennis Frölander</h4>


## Kort info:

Identity-databasen är tom så man är tvungen till att göra en helt ny användare första gången man startar hemsidan och den blir admin, alla andra blir som standard users men det går att ändra på inne i admin backoffice om man vill ge en annan roll. Produkterna visas upp på första sidan med hjälp av 3 taggar (New, Featured och Popular). Showcasen randomar fram en Featured produkt varje gång sidan uppdateras. Best Collection använder sig av taggen new, uptosale av 2 av de högsta rabatterna som finns på produkten och karusellen använder sig av popular taggen.


## Hur man startar programmet:
***Ändra connectionstrings i appsettings.json*** 

```"ConnectionStrings": {
    "Identity": "Identity-connectionstring",
    "Data": "mainDb-connection string"
  }
  ```
  
  ***Se till att du lagt till en connection mellan sqlserver och din lokaladatabas som finns i Models > Contexts > Databases (IdentityDatabase / MainDb).***
