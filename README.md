<h1 align="center">Word-Net Problem</h1>
<div align="center"><strong>Algorithm Project</strong></div>
<div align="center"><strong>Faculty of Computer and Information Sciences - Ain Shams University</strong></div>
<br><br/>
<h2><strong>Description</strong></h2>
<div> Read this PDF for description and problem definition : </div>
<p> https://drive.google.com/drive/folders/1qbO0qFh09IFlg1AH0a0PUiFu8DWzpP6F </p>
<h2><strong>Used Data Structure</strong></h2>

- To store information of “synsets” file :

 1. A Dictionary “Words” with a string as a key denoting the 
word, and a list of integers referring to synsets to which the 
key string belongs.
The Dictionary generic class provides a mapping from a set 
of keys to a set of values. Each addition to the dictionary 
consists of a value and its associated key. Retrieving a value 
by using its key is very fast, close to O (1) because the 
Dictionary class is implemented as a hash table.
If Count is less than the capacity, this method approaches 
an O (1) operation. If the capacity must be increased to 
accommodate the new element, this method becomes an 
O(n) operation, where n is Count.
“Words” helped us to map nouns to synsets in no time.

 2. List of List of strings “Synsets” to keep the words belonging 
to each synset and it takes time O (1) to be accessed.
“Synsets” helped with mapping synsets to nouns in no time.

- To store information of “hypernyms” file:

 1. List of List of integers “Graph” holding data of each synset,
and its root and it takes time O (1) to be accessed.
“Graph” helped with the Shortest Common Ancestor
(SCA) algorithm.


<h2><strong>Analysis</strong></h2>
<strong>❖ Efficient Distance And SCA between Two Synsets IDs : </strong>

The total Complexity is O(m) where m is the number of the synsets in the way to 
root from the current two synsets (as shown in the graph below).
The Complexity of calculating SCA and Distance between two nouns using this 
algorithm will be O(A*B*m) where A and B are the number of synsets that each 
noun belongs to.

<strong>❖ Efficient Distance and SCA between Two Nouns : </strong>

The same Algorithm is used to calculate the SCA for two synsets, the difference 
is in the initialization step, however, this algorithm takes less time to calculate 
the Distance and SCA between two nouns than the Efficient SCA.
The total Complexity is O(m + A*B) where m is the number of the synsets in the 
way to root from all the synsets used synsets, and (A, B) are the number of synsets that each noun belongs to.

<strong>In each line of the code, there is a comment of its complexity.</strong>

<h2>Contributors</h2>

- <a href="https://github.com/MotazAh">Elmoatazbellah Ahmed</a>

- <a href="https://github.com/noora-ekramy">Nora Ekramy</a>

- <a href="https://github.com/Nourhan-Mahmoud">Nourhan Mahmoud</a>
