import React, { useEffect, useState } from 'react';
import moment from 'moment';
import axios from 'axios';

import './App.css';

function App() {
    const [plantList, setPlantList] = useState([]);

    useEffect(() => {
        getPlantList();
    }, []);

    useEffect(() => {
        handleAlertPlantWater();
    }, [plantList]);

    const getPlantList = async () => {
        const getPlantListResponse = await axios.get(
            `https://localhost:7160/api/WaterPlant/GeAlltWaterPlant`,
            {
                headers: {
                    'Content-Type': 'application/json',
                },
            }
        );
        if(getPlantListResponse.status === 200) {
            setPlantList(getPlantListResponse.data)
            if(getPlantListResponse.data.testingMesssage) {
                console.log(getPlantListResponse.data.testingMesssage);
                alert(getPlantListResponse.data.testingMesssage);
            }
        }else {
            console.log('Get plant list failed');
        }
    };

    const handleWaterPlant = async(plantId) => {
        const response = await axios.post(
            `https://localhost:7160/api/WaterPlant/SaveWaterPlant?id=${plantId}`,
            {
                headers: {
                    'Content-Type': 'application/json',
                },
            }
        );
        if(response.status === 200) {
            if(response.data.isSuccess) {
                getPlantList();
                if(response.data.testingMesssage) {
                    console.log(response.data.testingMesssage);
                    alert(response.data.testingMesssage);
                }
                return true;
            } else {
                console.log(response.data.testingMesssage);
                alert(response.data.testingMesssage);
                return false;
            }
        } else {
            console.log('Get watered plant failed');
            return false;
        }
    }

    const startWatering = async(plantId) => {
        const stopWater = await handleWaterPlant(plantId);

        if(stopWater){
            setTimeout(() => {
                stopWatering(plantId);
            }, 10000);
        }
    };

    const stopWatering = plantId => {
        handleWaterPlant(plantId);
    };

    const handleAlertPlantWater = () => {
        plantList.map(plant => {
            var currentDate = moment();
            var duration = moment.duration(currentDate.diff(plant.waterTime));
            var hours = duration.asHours();
            if (hours > 6) {
                console.log(`${plant.pName} needs water`);
                alert(`${plant.pName} needs water`);
            }
        });
    };

    return (
        <div className="App">
            {plantList.map(item => (
                <div className="list-item" key={`${item.pName}-${item.pId}`}>
                    <div className="plant-details">
                        <p className="plant-name">
                            {item.pName}
                            <span className="watering-status">
                                {item.isWatering && 'watering'}
                            </span>
                        </p>
                        <span className="mr-5">{item.waterStatus}</span>
                        <span>{item.waterTime}</span>
                    </div>
                    <button
                        onClick={() => startWatering(item.pId)}
                        disabled={item.isWatering}
                    >
                        Click to water
                    </button>
                </div>
            ))}
        </div>
    );
}

export default App;
