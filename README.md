# Sort
This solution consists of two projects.
## SortAPI
Contains the main funcionality - array of numbers sorting. <br>
To post an array for sorting, call POST endpoint ``localhost:58583/api/sorting`` with body ([1, 2, 10, -11, 100]).<br>
To get latest post result, call GET endpoint ``localhost:58583/api/sorting``.<br>
To get latest post performance, call GET endpoint ``localhost:58583/api/sorting/performance``.<br>
There are two sorting algorithms implemented:
* Bubble Sort
* Selection Sort <br>

## TestSort
Contains tests for the SortAPI functionality
