import React, { useState } from 'react';
import { Container, TextField, Button, Typography } from '@mui/material';
import dayjs from 'dayjs';
import axios from 'axios'

const AddMaaserPage = () => {

    const [date, setDate] = React.useState(dayjs(new Date()).format('YYYY-MM-DD'));

    const [recipient, setRecipient] = useState()

    const [amount, setAmount] = useState()

    const onButtonClick = () => {
        axios.post('/api/maaser/addmaaser', { recipient: recipient, amount: amount, date: date })
    }

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Maaser
            </Typography>
            <TextField label="Recipient" variant="outlined" fullWidth margin="normal" onChange={e => setRecipient(e.target.value)} />
            <TextField label="Amount" variant="outlined" fullWidth margin="normal" onChange={e => setAmount(e.target.value)} />
            <TextField
                label="Date"
                type="date"
                value={dayjs(date).format('YYYY-MM-DD')}
                onChange={e => setDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button variant="contained" color="primary" onClick={onButtonClick}>Add Maaser</Button>
        </Container>
    );
}

export default AddMaaserPage;