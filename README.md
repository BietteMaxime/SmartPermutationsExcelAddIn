Smart Permutations Excel 2010 Add-In
====================================

This Excel Add-In simplify the creation of list of permutations. You need to specify a list of possible values and a set of rules in order to get the permutation you want.


Installation
------------

If you want to compile from the source, just use Visual Studio 2010 and compile. The references used should be included.

Once you have the binaries, you can execute the VSTO file that will propose you to install the Add-In.

Usage
-----

You need the possible values and the rules.

The possible values have to be listed in columns. Each column represent a set of values for the permutations.

The rules have to be listed in columns too. Each column is a set of rules that will generate one group of permutations. The first row in the column have to be the header that will identify the rule, then you have to make one row for each of the possible values column. Those rows will restrict the permutations.

The rules can be:
* IN ('<value>', ...)
* NOT ('<value>', ...)
* BETWEEN ('<float value>','<float value>')
* ALL

License
-------

This project is release under the MIT License. Please read the LICENSE.txt file for more information.