import React from "react";
import styled, { keyframes } from "styled-components";
const LoadingSpinner = () => {
    return (
        <Wrapper>
          <Loader>
            <Dot delay="-0.32s" />
            <Dot delay="-0.16s" />
            <Dot />
          </Loader>
        </Wrapper>
      );
};
const Wrapper = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
`;

const Loader = styled.div`
  display: inline-block;
  position: relative;
  width: 64px;
  height: 64px;
`;

const dotAnimation = keyframes`
  0%, 80%, 100% {
    transform: scale(0);
  }
  40% {
    transform: scale(1);
  }
`;

const Dot = styled.div`
  position: absolute;
  top: 0;
  width: 16px;
  height: 16px;
  border-radius: 8px;
  background-color: var(--primary-color);
  animation: ${dotAnimation} 1.2s infinite ease-in-out both;
  animation-delay: ${props => props.delay};
  &:nth-child(2) {
    left: 16px;
    animation-delay: ${props => props.delay || "-0.16s"};
  }
  &:nth-child(3) {
    left: 32px;
    animation-delay: ${props => props.delay || "0"};
  }
`;
export default LoadingSpinner;
