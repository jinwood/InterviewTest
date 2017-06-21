## King's Court Trust Code Test

#### This is my submission to the King's Court Trust code test.
I addressed the final two points in the documentation:

* Write some unit tests

* Implement server-side paging

I wrote some simple unit tests to cover all the methods found within the  "People" stack. So controller, service and repository. Including class initialization (checking for null arguments, etc), testing that the methods call the correct things in the layer below, and testing results from the repository.

I split out the stream reader class from within the repository as it was tightly coupled to the repository which made writing a test using test data not possible.

Finally, I added a simple endpoint to the Person controller which allowed a page (slice) of the repository to be returned.

Given more time, I would move the repositories data source to something more scalable (SQL db with EF/Dapper/etc), add models to the api layer with something to map to and from (Automapper), and split out the core definitions into their own core project (adopt onion architecture principals).

_Submitted by Julian Inwood_