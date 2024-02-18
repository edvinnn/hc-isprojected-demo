# Steps to reproduce
1. Run the the `Demo.Api` project.
2. Execute the example demo queriy provided in `Demo.Api.http`
3. Observe the error message: `"A composite type always needs to specify a selection set."`

### Futher details
4. Stop the application.
5. Uncomment line 12 in `Models/Book.cs` https://github.com/edvinnn/hc-isprojected-demo/blob/8919b66d1667ec9a87b7663b734591604877c714/Models/Book.cs#L12
6. Run the `Demo.Api` project again, execute the request and watch it complete successfully.

### Additional comments
I would expect the attribute on line 12 in `Models/Book.cs` to work. The queryable returned from the resolver includes the navigation property `Author`, so it feels like it should be possible from a technical point of view to also access it in the field middleware.
