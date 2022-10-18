import React from 'react'
import styled from 'styled-components'
import 'bootstrap-icons/font/bootstrap-icons.css';

const Header = () => {
    return (
        <Header_Main>
            <Profile_button href="">
                <i class="bi bi-person-circle"></i>
            </Profile_button>
        </Header_Main>
    )
}

export default Header

const Header_Main = styled.header`
    width: 100%;
    height: 8%;
    display: flex;
    flex-direction: row;
    justify-content: end;    
    background-color: #67A89D;
`

const Profile_button = styled.a`
    font-size: 1.6rem;
    color: black;
    width: auto;
    height: 30px;
    margin: 1rem 2rem;

    &:hover{
        color: black;
    }
`