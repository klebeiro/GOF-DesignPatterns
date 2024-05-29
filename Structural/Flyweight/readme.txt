Avoid redundancy when storing data

E.g., MMORPG
	- You have plenty of users with identical first/last names
	- No sense in storing same first/last name over and over again
	- Store a list of names and pointers to them

 .NET performs string interning, so an identical string is stored only once

 "A space optimization technique that lets us use less memory by storing externally the data associated with similar objects"