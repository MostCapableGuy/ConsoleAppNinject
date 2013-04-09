Ninject in a console application
================================================

# Info

A simple 3 tier architecture created from a Console Application.
Built with Scaffolding from CodePlanner nuget package.

# Note

Will create a SDF file in the bin folder.
If you want to use another database uncomment the connecitonsstring in the app.config and enter a sa password. 
The project will then create the database for you.

# DomainModel

The demo project uses a single class (Person) for domainmodel.
To use your model... Create your own under Core\Model and inherit PersistenEntity.

Then run "Scaffold CodePlanner.ScaffoldBackend"

================================================


Regards
Uffe Björklund