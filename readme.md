## Scenario
Executing several tasks in parallel, where more than one throws exception. I want to catche all the exceptions.

### The cathed exception is only the first one thrown
Yes, the exception catched is only the first exception thrown. The list of all the exceptions is actually kept in the AggregateException kept in the property _Exception_ of the _compositeTask_.

So, yes, the handling is that ugly. But there is more.

### AggregateException ToSting() method doesn't spit all.
Exactly. [Here](https://stackoverflow.com/questions/34433446/wrapped-aggregateexception-reports-just-first-exception-in-tostring-method) they explain it.
So keep an eye when logging the Aggregate exception or sending it through the wire, because info will be lost.