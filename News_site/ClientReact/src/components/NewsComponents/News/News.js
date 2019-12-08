import React from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import Moment from 'react-moment';
import { Button } from 'react-bootstrap';
 
const redirectToNewsDetails = (id, history) => {
    history.push('/newsDetails/' + id);
}
 
const redirectToUpdateNews = (id, history) => {
    history.push('/updateNews/' + id);
}
 
const rediterctToDeleteNews = (id, history) => {
    history.push('/deleteNews/' + id);
}
 
const news = (props) => {
    return (
        <Aux>
            <tr>
                <td>{props.news.name}</td>
                <td><Moment format="DD/MM/YYYY">{props.news.date}</Moment></td>
                <td>{props.owner.body}</td>
                <td>
                    <Button onClick={() => redirectToNewsDetails(props.news.id, props.history)}>Details</Button>
                </td>
                <td>
                    <Button bsStyle="success" onClick={() => redirectToUpdateNews(props.news.id, props.history)}>Update</Button>
                </td>
                <td>
                    <Button bsStyle="danger" onClick={() => rediterctToDeleteNews(props.news.id, props.history)}>Delete</Button>
                </td>
            </tr>
        </Aux>
    )
}
 
export default news;