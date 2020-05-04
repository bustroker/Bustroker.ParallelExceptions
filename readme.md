## Catching exceptions thrown during parallel tasks execution
The Aggregate exception containing all the exceptions thrown in all the tasks is kept by the _wholeTask_ task in the _Exception_ property.
By the way, **the exception catched is the first exception thrown, NOT the AggregateException**.
So, yes, the handling is this ugly.