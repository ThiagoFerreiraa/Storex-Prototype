import React, { useRef } from 'react'
import './Login.css';
import video from "../../assets/background_growex.mp4"
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';
import Swal from 'sweetalert2';
import { Loader } from '../../components/Loader/Loader';

const Login = () => {
    const videoEl = useRef(null);
    const URL_API_LOGIN = process.env.REACT_APP_URL_API_LOGIN;
    const navigate = useNavigate();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [showLoader, setShowLoader] = useState("none")

    const CheckUser = (e) => {
        e.preventDefault();
        setShowLoader("")
        axios.post(`${URL_API_LOGIN}/Authentication`, {
            username: username,
            password: password,
            token: "",
            role: ""
        }).then((response) => {
            if (response.data.Status == false) {
                setShowLoader("none")
                Swal.fire({
                    icon: 'error',
                    title: 'STOP!',
                    text: 'Username or Password are Wrong..!Please try again!'
                })
            } else {
                localStorage.setItem("token", response.data.token);
                navigate("../Dashboard")
            }
        }).catch((error) => {
            console.log(error)
        })
    }

    useEffect(() => {

    })

    return (
        <div>
            <Loader hidden = {showLoader}/>
            <div className='container'>
                <div className='row justify-content-center align-items-center vh-100 '>
                    <div className='login_div'>
                        <h1>Storex</h1>
                        <form method='post' onSubmit={CheckUser}>
                            <div className='txt_field_login'>
                                <input type="text" name="username" className='input_login' required onChange={(e) => setUsername(e.target.value)} />
                                <span></span>
                                <label className='w-100'>Username</label>
                            </div>
                            <div className='txt_field_login'>
                                <input type="password" name="password" className='input_login' required onChange={(e) => setPassword(e.target.value)} />
                                <span></span>
                                <label className='w-100'>Password</label>
                            </div>
                            <div className='container text-center'>
                                {/* <Link to="dashboard"></Link> */}
                                <input type="submit" className='btn btn-primary w-50 button_login' name="" value="Login" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <video
                // style={{ height: "100%", width: "100%", margin: "0 auto" }}
                className='background_video'
                playsInline
                loop
                autoPlay
                muted
                alt="All the devices"
                src={video}
                ref={videoEl}
            />
        </div>
    )
}

export default Login