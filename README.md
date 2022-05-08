# Lincolle4net

By importing this library in your project, you are going to access some methods as extensions which will help you while filtering Linq and Collections in C#.

For now the current version supports only `WhereIf` on **List**, **Enumerable**, **Queryable**, **Stack**, **Dictionary** and **Collection**.

```csharp
var filter = "DRC";
var countries = (new List<string>() { "USA", "Canada" ,"DRC", "Uganda", "China" })
  .AsQueryable()
  .WhereIf(!string.IsNullOrEmpty(filter), c => c == filter);
```

Note that, on each call of `WhereIf`, an inline `IF` condition is applied on specified generics. Without using this package, the above code could be written as below:

```csharp
var filter = "DRC";
var countries = (new List<string>() { "USA", "Canada" ,"DRC", "Uganda", "China" })
  .AsQueryable();

if(!string.IsNullOrEmpty(filter))
{
    countries.Where(c => c == filter);
}

```

Use this library while filtering Dictionaries.

```csharp
var dic = new Dictionary<string, string>
{
    { "test", "val" },
    { "test2", "val2" }
};
var filter = "va";

var data = dic.WhereIf(!string.IsNullOrEmpty(filter), c => c.Value.StartsWith(filter));
```

### Roadmap

- [x]   **WhereIf**
- [ ]   AddIf
- [ ]   RemoveIf

### Contribution

The project is opened for community contribution. To do this, you've to fork this project, perform all operation, finaly push changes on your forked project.

> Create a pull request if you want your changes to be merged to the main branch.
