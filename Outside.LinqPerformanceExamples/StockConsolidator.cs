using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;

namespace Outside.LinqPerformanceExamples
{
  public  class StockConsolidator
    {
      //  [Benchmark]
        public static IEnumerable<ProductStock> ConsolidateStocksUsingDictionary(List<ProductStock> productStocks, List<ProductStock> anotherProductStocks)
        {
            var anotherProductStocksAsDictionary = anotherProductStocks.ToDictionary(p => p.Sku, p => p);
            foreach (var productStock in productStocks)
            {
                var otherProductStock = anotherProductStocksAsDictionary[productStock.Sku];
                yield return new ProductStock
                {
                    Sku = productStock.Sku,
                    StockLevel = productStock.StockLevel + otherProductStock.StockLevel
                };
            }
        }
      //  [Benchmark]
        public static IEnumerable<ProductStock> ConsolidateStocks(List<ProductStock> productStocks, List<ProductStock> otherProductStocks)
        {
            foreach (var productStock in productStocks)
            {
                var otherProductStock = otherProductStocks.First(p => p.Sku == productStock.Sku);
                yield return new ProductStock
                {
                    Sku = productStock.Sku,
                    StockLevel = productStock.StockLevel + otherProductStock.StockLevel
                };
            }
        }
        
    }
}