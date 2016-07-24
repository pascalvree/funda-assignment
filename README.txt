Programming assignment

Hi,

At funda, when we recruit software developers, we're actually more interested in finding people who love to program than in degrees and diploma's. Our ideal programmer may not have a lot of experience working in a large company, but they've been writing code since they were young and can't think of anything else they'd rather do. I love talking with programmers not about their resume but about real projects and real code. That's the purpose of this assignment. It gives us something we can discuss. The solution doesn't have to be brilliant but it will help shape our conversation. (see also #11 from Joel's list). The assignment is not intended to take hours to complete.

Good luck,

Hendrik Jan Visser (Software Architect funda)

--

Information to help you complete the assignment

Useful translations:
koop = purchase
tuin = garden
makelaar = real estate agent

The funda API returns information about the objects that are listed on funda.nl which are for sale. An example of one of the URLs in our REST API is: 
http://partnerapi.funda.nl/feeds/Aanbod.svc/[key]/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=25

A temporary key which can be used for this exercise is: 005e7c1d6f6c4f9bacac16760286e3cd 
You will need to replace [key] with the temporary key.

Most of the parameters that you can pass are self explanatory. The parameter 'zo' (zoekopdracht or search query) is the same as the key used in funda.nl URLs. For example the URL shown above searches for houses in Amsterdam with a garden: http://www.funda.nl/koop/amsterdam/tuin/. 

The API returns data about the object in XML. If you add the key 'json' between 'Aanbod.svc' and [key], a JSON representation of the data will be returned instead of XML.

--

The assignment

Determine which makelaar's in Amsterdam have the most object listed for sale. Make a table of the top 10. Then do the same thing but only for objects with a tuin which are listed for sale. For the assignment you may write a program in the language of your choice and you may use any libraries that you find useful.

-- 

Tips:

If you perform too many API requests in a short period of time (around 100 per minute), the API wil reject the requests. You should take this into account.
Don't forget to comment your code a bit, I will read it!

-- 

Funda (key 005e7c1d6f6c4f9bacac16760286e3cd)
- http://partnerapi.funda.nl/feeds/Aanbod.svc/[key]/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=25

json, makelaars in amsterdam, listed for sale without garden (no paging): http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/&page=1&pagesize=5000
json, makelaars in amsterdam, listed for sale with garden (no paging): http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=1000