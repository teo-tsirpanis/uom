match (:Person {name:"Tom Hanks"})-[:ACTED_IN]->(m:Movie)<-[:ACTED_IN]-(p:Person)
where p.name = "Meg Ryan" or p.name = "Kevin Bacon"
return m

match (p:Person)-[:ACTED_IN]->(:Movie {title: "Snow Falling on Cedars"}), (p)-[:ACTED_IN]->(:Movie {title: "The Green Mile"})
return p.name, p.born

match (p:Person)-[:ACTED_IN]->(:Movie)<-[:ACTED_IN]-( :Person {name: "Tom Cruise"})
where not ((p)-[:ACTED_IN]->(:Movie)<-[:ACTED_IN]-(:Person {name: "Tom Hanks"})
    or (p)-[:ACTED_IN]->(:Movie)<-[:ACTED_IN]-(:Person {name: "Kevin Bacon"}))
return p

match (m:Movie)<-[:ACTED_IN]-(:Person)-[:ACTED_IN]->(:Movie {title: "A Few Good Men"}), (p:Person)-[:ACTED_IN]->(m)
return m, count(p) as c
order by c descending

match (p: Person)
where not (p)-[:ACTED_IN]->(:Movie)
return p
