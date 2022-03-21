import instance from "../lib/instance";
import { useEffect, useState } from "react"

const Person = () => {

  
  const [persons, setPerson] = useState(null);
  const [counter, setCounter] = useState(0);

  useEffect(() => {

    instance.get('contact')
    .then((result) => {

      setPerson(JSON.parse(result.data))

    })
    .catch((result) => {
      console.log(result);
    })
  }, []);

  return (
    <div>
      <table border="1px" width="100%" cellspacing="10" cellpadding="10">
        <thead>
          <tr>
            <th>Идентификатор</th>
            <th>ФИО</th>
            <th>Email</th>
            <th>Телефон</th>
            <th>Метка</th>
          </tr>
        </thead>
        <tbody>
          
          {persons && persons.map(person =>
              <tr key={person.idPerson}>
                <td>{counter += 1}</td>
                <td>{person.secondName + " " + person.firstName + " " + (person.patronymic ? person.patronymic : "")}</td>
                <td>{person.email}</td>
                <td>{person.telephone}</td>
                <td>{person.idTag}</td>
              </tr>
              )}
        </tbody>
      </table>
    </div>
  )
}
  
  export default Person