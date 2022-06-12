import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button } from 'semantic-ui-react';

interface IVotesCard {
  icon: string;
  label: string;
  content: number;
  labelPosition: 'left' | 'right';
}

const VotesCard = ({ icon, label, content, labelPosition }: IVotesCard) => {
  return (
    <Button
      icon={icon}
      content={label}
      label={{ as: 'a', basic: true, content: content }}
      labelPosition={labelPosition}
    />
  );
};

export default observer(VotesCard);
