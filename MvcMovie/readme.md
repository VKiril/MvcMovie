In the Package Manager Console window at the PM> prompt enter

	Enable-Migrations -ContextTypeName MvcMovie.Models.MovieDBContext

The next step is to create a DbMigration class for the initial migration. This migration creates a new database, that's why you deleted the movie.mdf file in a previous step.
The name "Initial" is arbitrary and is used to name the migration file created.

	add-migration Initial

	update-database

Add new field to row called Rating, add it to crud. Create new db migration

	add-migration Rating

	Build the solution, and then enter the update-database command in the Package Manager Console window.

	update-database

