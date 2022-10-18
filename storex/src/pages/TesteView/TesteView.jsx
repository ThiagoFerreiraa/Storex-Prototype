import React from 'react'
import { useState } from 'react'
import axios from 'axios';
import { useEffect } from 'react';

const TesteView = () => {

    const BASE_URL = process.env.REACT_APP_URL_API;
    // const BASE_URL = "https://localhost:7101/api/Person";

    const [data, setData] = useState([]);

    const GetPeople = async () => {
        await axios.get(BASE_URL).then(response => {
            setData(response.data)
        }).catch(error => {
            console.log(error)
        })
    }

    useEffect(() => {
        GetPeople();
    })

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <td>id</td>
                        <td>Nome</td>
                        <td>CPF</td>
                    </tr>
                </thead>
                <tbody>
                    {data.map(person => (
                        <tr key={person.Id}>
                            <td>{person.Id}</td>
                            <td>{person.Name}</td>
                            <td>{person.DocumentNumber}</td>
                            <td>
                                <button className='btn btn-primary'>Edit</button>{"  "}
                                <button className='btn btn-danger'>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default TesteView