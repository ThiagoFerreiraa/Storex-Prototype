import React from 'react'
import { InfinitySpin } from 'react-loader-spinner';
import styled from 'styled-components';

export const Loader = (props) => {
    return (
        <div className='loader_container' style={{display: props.hidden}}>
            <Div_Loader>
                <InfinitySpin
                    width='200'
                    color="#4fa94d"
                />
            </Div_Loader>
        </div>
    )
}

const Div_Loader = styled.div`
    width: fit-content;
    margin: auto;
    height: inherit;
    display: flex;
    align-items: center;
`