# Migrations

## Adding a Migration

Open the Package Manager Console from the menu 
**Tools -> NuGet Package Manager -> Package Manager Console** in **Visual Studio** and execute the following command to add a migration.
~~~
PM> Add-Migration "[NAME]"
~~~

## Creating or Updating the Database
Use the following command to create or update the database schema.
~~~
PM> Update-Database
~~~

## Removing a Migration
You can remove the last migration if it is not applied to the database. 
Use the following remove commands to remove the last created migration 
files and revert the model snapshot.
~~~
PM> Remove-migration
~~~

## Reverting a Migration
Suppose you changed your domain class and created the second migration 
named MySecondMigration using the add-migration command and applied this 
migration to the database using the Update command. But, for some reason, 
you want to revert the database to the previous state. In this case, 
use the update-database `<migration name>` command to revert the database to the specified previous migration snapshot.
~~~
PM> Update-database MyFirstMigration
~~~

