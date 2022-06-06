import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { SmallCard } from "../../components/SmallCard/SmallCard";
import { ICoachesWorkouts } from "../../models/interface/ICoachesWorkouts";
import { ISubscription } from "../../models/interface/ISubscription";
import { IUser } from "../../models/interface/IUser";
import UserService from "../../services/UserService";

import "./coachPage.scss";

const CoachPage = () => {
  const [coachData, setCoachData] = useState<IUser[]>([]);
  const [active, setActive] = useState<boolean>(false);

  useEffect(() => {
    setActive(false);

    let promises = [
      UserService.getAllCoach(),
      UserService.getCoachesWorkoutsCount(),
    ];

    Promise.all(promises).then((data:any) => {
      data[1].data.shift();
      let temp: IUser[] = [];
      for (let i = 0; i < data[0].data.length; i++) {
        temp.push({
          id: data[0].data[i].id,

          name: data[0].data[i].name,

          dateOfBirth: data[0].data[i].dateOfBirth,
          phone: data[0].data[i].phone,

          roleId: data[0].data[i].roleId,

          description: data[0].data[i].description,
          directionId: data[0].data[i].directionId,
          CountOfWorkouts: data[1].data[i].countOfWorkouts,
        });
      }
      setActive(true);
      setCoachData(temp);
    });
  }, []);

  return (
    <div className="coach-page__container">
      {active &&
        coachData.map((data) => (
          <SmallCard key={data.id + data.name} type="coach" coach_data={data} />
        ))}
    </div>
  );
};

export default observer(CoachPage);
