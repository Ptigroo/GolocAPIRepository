using GolocAPI.CommandsAndQueries.Common;
using GolocAPI.Models;

namespace GolocAPI.Commands;

public record AddProductCategoryCommand(string Name, string Description) : ICommand<ProductCategoryModel>;
