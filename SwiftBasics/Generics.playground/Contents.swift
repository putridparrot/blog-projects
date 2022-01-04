/**
 Example of using generics within a protocol and basic implementation.
 Also includes basic example of exception handling
 */

protocol Container {
    associatedtype Item
    
    mutating func add(item: Item) -> Int
    func get(index: Int) throws -> Item
}

enum ContainerError: Error {
    case OutOfRangeError
}

struct MyContainer<T>: Container {
    typealias Item = T
    
    private var items: [Item] = []
    
    mutating func add(item: T) -> Int {
        items.append(item)
        return items.count - 1
    }
    
    func get(index: Int) throws -> T {
        guard index >= 0 && index < items.count else {
            throw ContainerError.OutOfRangeError
        }
        return items[index]
    }
}

var container = MyContainer<String>()
container.add(item: "One")
container.add(item: "Two")

print((try? container.get(index: 0)) ?? "Error")
print(try! container.get(index: 1))

do {
    try container.get(index: 100)
} catch {
    print("Error \(error)")
}
