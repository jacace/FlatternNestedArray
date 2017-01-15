This project contains 3 ways to flattern a nested array.
Example: [[1,2,[3]],4] -> [1,2,3,4]. 

Notes: The first two options (under the class PoorManSolution) are included for reference purposes.
       At this time, it seems that the third option is the best but other ways do exist (for example: using Generics).
       Only the third option contains Unit tests using NUnit.
       A recursive solution would be also applicable because is built in sub-problems.
       But each recursive call would add a new layer to the stack, so it is not space efficient.
       Having this into account the preferred approach is iterative (plus, the recursive code wouldn't be significatvely shorter).

Option 1: this option would use the class PoorManSolution.ArrayElement which has three fields to store (exclusively) an integer or 
          an array of integers or an array of its own datatype. 
          The problem with this option is that we would need a lot of comparisons to determinate which field is being used and 
          memory space would be wasted storing a pointer to null in the unused properties.

Option 2: this option described in the function PoorManSolution.PoorNestedArray.Flattern does the trick but using the data type object
          to allow storing data of different types.
          This option does the trick but it is computationally expensive because of the boxing / unboxing. 
          When boxing, the new object in the stack references an object in the heap.

Option 3: this option implemented in the file Common uses OOP principles so there is an custom implementation for each case.
